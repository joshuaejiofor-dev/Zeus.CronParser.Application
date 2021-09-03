using System.Collections.Generic;

namespace Zeus.CronParser.Application.Services.Interfaces
{
    public interface ICronParserService
    {
        List<string> ParseMinute(string expression);
        List<string> ParseHour(string expression);
        List<string> ParseDayOfMonth(string expression);
        List<string> ParseMonth(string expression);
        List<string> ParseDayOfWeek(string expression);
    }
}
