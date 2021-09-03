using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;
using Zeus.CronParser.Application.DependencyInjection;
using Zeus.CronParser.Application.Factory;
using Zeus.CronParser.Application.Factory.Interfaces;
using Zeus.CronParser.Application.Services;
using Zeus.CronParser.Application.Services.Interfaces;

namespace Zeus.CronParser.Application
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                    .Build();

            services.AddSingleton(c => configuration)
                    .AddSingleton(c => Log.Logger)
                    .AddSingleton<CronParser>()
                    .AddSingleton<ICronParserService, CronParserService>()
                    .AddSingleton<ICronParserProviderFactory, CronParserProviderFactory>()                        
                    .AddProviders();

            return services;
        }
    }
}
