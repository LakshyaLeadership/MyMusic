using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using MyMusic.Services;
using NLog;

namespace MyMusic.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(s => s.AddAutofac(cb =>
                {
                    cb.RegisterBuildCallback(OnBuild);
                }));

        private static void OnBuild(IContainer container)
        {
            AutofacServiceProvider serviceProvider = new AutofacServiceProvider(container);
            AutofacDi.ConfigureNLog(serviceProvider);
        }
    }
}
