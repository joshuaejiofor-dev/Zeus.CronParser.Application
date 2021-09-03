using System.Collections.Generic;
using System.Linq;
using Zeus.CronParser.Application.Providers.Interfaces;
using Zeus.CronParser.Application.Requests;

namespace Zeus.CronParser.Application.Providers
{
    public class AsteriskCronParserProvider : ICronParserProvider
    {
        public List<string> Parse(ParseRequest parseRequest)
        {
            var allowedValues = parseRequest.AllowedValueRange.Split("-").Select(int.Parse).ToList();
            var store = new List<string>();
            for (int i = allowedValues[0]; i <= allowedValues[1]; i++)
            {
                store.Add(i.ToString());
            }
            return store;
        }
    }
}
