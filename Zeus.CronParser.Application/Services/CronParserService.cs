using System.Collections.Generic;
using System.Linq;
using Zeus.CronParser.Application.Factory.Interfaces;
using Zeus.CronParser.Application.Requests;
using Zeus.CronParser.Application.Services.Interfaces;

namespace Zeus.CronParser.Application.Services
{
    public class CronParserService : BaseService, ICronParserService
    {
        public CronParserService(ICronParserProviderFactory cronParserProviderFactory) 
            : base(cronParserProviderFactory) { }
        public List<string> ParseMinute(string expression)
        {
            var parseRequest = new ParseRequest
            {
                Expression = expression,
                AllowedSpecialChars = ", - * /".Split(" ").ToList(),
                AllowedValueRange = "0-59"
            };

            return CronJobParse(parseRequest);
        }

        public List<string> ParseHour(string expression)
        {
            var parseRequest = new ParseRequest
            {
                Expression = expression,
                AllowedSpecialChars = ", - * /".Split(" ").ToList(),
                AllowedValueRange = "0-59"
            };

            return CronJobParse(parseRequest);
        }

        public List<string> ParseDayOfMonth(string expression)
        {
            var parseRequest = new ParseRequest
            {
                Expression = expression,
                AllowedSpecialChars = ", - * ? / L W C".Split(" ").ToList(),
                AllowedValueRange = "1-31"
            };

            return CronJobParse(parseRequest);
        }

        public List<string> ParseMonth(string expression)
        {
            var parseRequest = new ParseRequest
            {
                Expression = expression,
                AllowedSpecialChars = ", - * /".Split(" ").ToList(),
                AllowedValueRange = "1-12"
            };

            return CronJobParse(parseRequest);
        }

        public List<string> ParseDayOfWeek(string expression)
        {
            var parseRequest = new ParseRequest
            {
                Expression = expression,
                AllowedSpecialChars = ", - * ? / L C #".Split(" ").ToList(),
                AllowedValueRange = "1-7"
            };

            return CronJobParse(parseRequest);
        }

    }
}
