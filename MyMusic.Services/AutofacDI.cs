using System;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using MyMusic.EFCoreDbFirst;
using MyMusic.Repositories;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Extensions.Logging;
using LogLevel = NLog.LogLevel;

namespace MyMusic.Services
{
    public class AutofacDi
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration config = configurationBuilder.Build();

            RegisterDbContext(containerBuilder, config);

            containerBuilder.RegisterType<AlbumRepository>().As<IRepository<Album>>();
            containerBuilder.RegisterType<AlbumService>().As<IAlbumService>();

            RegisterAutoMapper(containerBuilder);
            RegisterNLog(containerBuilder);
        }

        private static void RegisterDbContext(ContainerBuilder containerBuilder, IConfiguration config)
        {
            containerBuilder.Register(componentContext =>
            {
                DbContextOptionsBuilder<MyMusicDbFirstContext> opt = new DbContextOptionsBuilder<MyMusicDbFirstContext>();
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                return new MyMusicDbFirstContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }

        public static void ConfigureNLog(AutofacServiceProvider serviceProvider)
        {
            ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddNLog(new NLogProviderOptions
            {
                CaptureMessageTemplates = true,
                CaptureMessageProperties = true,
                ShutdownOnDispose = true
            });


            LoggingConfiguration nlogConfig = new LoggingConfiguration();
            FileTarget logfile = new FileTarget("logfile") { FileName = "MyMusic3.log" };
            ConsoleTarget logconsole = new ConsoleTarget("MyMusicConsole");

            nlogConfig.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            nlogConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = nlogConfig;
        }

        private static void RegisterNLog(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<LoggerFactory>()
                .As<ILoggerFactory>()
                .SingleInstance();
            containerBuilder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .SingleInstance();
        }

        private static void RegisterAutoMapper(ContainerBuilder containerBuilder)
        {
            MapperConfiguration configAuto = new MapperConfiguration(cfg => { cfg.AddProfile(new MyMusicAutoMaperProfile()); });

            containerBuilder.Register(componentContext =>
                {
                    IMapper mapper = configAuto.CreateMapper();
                    return mapper;
                })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}