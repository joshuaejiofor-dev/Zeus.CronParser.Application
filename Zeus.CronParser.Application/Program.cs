using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.IO;

namespace Zeus.CronParser.Application
{
    public class Program
    {
        public static void Main()
        {
            SetupLogging();
            Log.Information("Starting the application host");

            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<CronParser>().Run();            
        }

        private static void SetupLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(), Path.Combine(Directory.GetCurrentDirectory(), "Logs", "Application.log"),
                    retainedFileCountLimit: 7, fileSizeLimitBytes: null, rollingInterval: RollingInterval.Day, shared: true,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();    
            
        }
    }
}
