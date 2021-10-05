using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.IoC
{
    public static class ServiceHelper
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection CreateInstance(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }

    }
}
