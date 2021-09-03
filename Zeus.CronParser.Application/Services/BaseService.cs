using System.Collections.Generic;
using System.Linq;
using Zeus.CronParser.Application.Factory.Interfaces;
using Zeus.CronParser.Application.Requests;

namespace Zeus.CronParser.Application.Services
{
    public class BaseService
    {
        private readonly ICronParserProviderFactory _cronParserProviderFactory;

        public BaseService(ICronParserProviderFactory cronParserProviderFactory)
        {
            _cronParserProviderFactory = cronParserProviderFactory;
        }

        protected List<string> CronJobParse(ParseRequest parseRequest)
        {
            List<string> result = null;
            var allowedValues = parseRequest.AllowedValueRange.Split("-").Select(int.Parse).ToList();

            foreach (var specialChar in parseRequest.AllowedSpecialChars)
            {
                if (!parseRequest.Expression.Contains(specialChar)) continue;

                result = specialChar switch
                {
                    "," or "-" or "/" or "*" => _cronParserProviderFactory.Create(specialChar).Parse(parseRequest),
                    _ => new List<string> { parseRequest.Expression },
                };
            }

            if (result == null && int.TryParse(parseRequest.Expression, out int number))
                result = new List<string> { parseRequest.Expression };

            return result;
        }
    }
}
