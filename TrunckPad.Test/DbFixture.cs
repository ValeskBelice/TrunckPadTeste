using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Infra.CrossCutting.IoC;

namespace TrunckPad.Test
{
    public class DbFixture
    {
        public DbFixture()
        {
            var services = new ServiceCollection();
            RegistersServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }
        private static void RegistersServices(IServiceCollection service)
        {
            NativeInjectorMapping.RegisterServices(service);
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
