using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MyMusic.Services;

namespace MyMusic.XUnitTest
{
    public class AutofacUnitTestSetup
    {
        public static AutofacServiceProvider InitAutofac()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);

           var serviceProvider =  AutofacDi.Bootstrapper(containerBuilder);

            return serviceProvider;
        }
    }
}
