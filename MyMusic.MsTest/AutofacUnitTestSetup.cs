using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMusic.EFCoreDbFirst;
using MyMusic.Repositories;
using MyMusic.Services;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Extensions.Logging;
namespace MyMusic.MsTest
{
    public class AutofacUnitTestSetup
    {
        public static AutofacServiceProvider InitAutofac()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            AutofacDi.Register(containerBuilder);
            AutofacServiceProvider serviceProvider = new AutofacServiceProvider(containerBuilder.Build());
            AutofacDi.ConfigureNLog(serviceProvider);
            return serviceProvider;
        }
    }
}
