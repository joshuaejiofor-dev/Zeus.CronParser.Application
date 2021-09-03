using Serilog;
using System;
using System.Collections.Generic;
using Zeus.CronParser.Application.Services.Interfaces;

namespace Zeus.CronParser.Application
{
    public class CronParser
    {
        private readonly ICronParserService _cronParserService;
        private readonly ILogger _logger;

        public CronParser(ICronParserService cronParserService, ILogger logger)
        {
            _cronParserService = cronParserService;
            _logger = logger;
        }

        public void Run()
        {
            _logger.Information("Initialized Logging ..");
            var result = new Dictionary<string, List<string>>();

            string expression = "*/15 0 1,15 * 1-5 /usr/bin/find";
            var parts = expression.Replace("  ", " ").Split(" ");

            result.Add("minute", _cronParserService.ParseMinute(parts[0]));
            result.Add("hour", _cronParserService.ParseHour(parts[1]));
            result.Add("day of month", _cronParserService.ParseDayOfMonth(parts[2]));
            result.Add("month", _cronParserService.ParseMonth(parts[3]));
            result.Add("day of week", _cronParserService.ParseMonth(parts[4]));
            result.Add("command", new List<string> { parts[5] });

            Console.WriteLine();
            foreach (var item in result)
            {
                Console.WriteLine(string.Format("{0,-14}{1}", item.Key, string.Join(" ", item.Value.ToArray())));
            }

        }
    }
}
