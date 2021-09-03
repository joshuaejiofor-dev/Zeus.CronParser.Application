using System.Collections.Generic;
using System.Linq;
using Zeus.CronParser.Application.Providers.Interfaces;
using Zeus.CronParser.Application.Requests;

namespace Zeus.CronParser.Application.Providers
{
    public class CommaCronParserProvider : ICronParserProvider
    {
        public List<string> Parse(ParseRequest parseRequest)
        {
            return parseRequest.Expression.Split(",").ToList();
        }
    }
}
