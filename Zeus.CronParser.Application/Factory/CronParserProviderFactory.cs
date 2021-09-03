using Microsoft.Extensions.DependencyInjection;
using System;
using Zeus.CronParser.Application.Factory.Interfaces;
using Zeus.CronParser.Application.Providers;
using Zeus.CronParser.Application.Providers.Interfaces;

namespace Zeus.CronParser.Application.Factory
{
    public class CronParserProviderFactory : ICronParserProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CronParserProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICronParserProvider Create(string specialChar) => specialChar switch
        {
            "," => _serviceProvider.GetRequiredService<CommaCronParserProvider>(),
            "-" => _serviceProvider.GetRequiredService<DashCronParserProvider>(),
            "/" => _serviceProvider.GetRequiredService<BackslashCronParserProvider>(),
            "*" => _serviceProvider.GetRequiredService<AsteriskCronParserProvider>(),
            _ => null,
        };

    }
}
