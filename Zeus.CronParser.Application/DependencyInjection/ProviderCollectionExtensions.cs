using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zeus.CronParser.Application.Providers.Interfaces;

namespace Zeus.CronParser.Application.DependencyInjection
{
    public static class ProviderCollectionExtensions
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            var iProviders = new List<Type> { typeof(ICronParserProvider) };
            var applicationAssembly = Assembly.Load("Zeus.CronParser.Application");
            applicationAssembly.GetTypes()
                               .Where(item => item.GetInterfaces().Any(type => iProviders.Contains(type) || type.IsGenericType) && !item.IsInterface)
                               .ToList().ForEach(assignedTypes =>
                               {
                                    services.AddSingleton(assignedTypes);
                               });

            return services;
        }
    }
}
