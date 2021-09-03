using System.Collections.Generic;
using System.Linq;
using Zeus.CronParser.Application.Providers.Interfaces;
using Zeus.CronParser.Application.Requests;

namespace Zeus.CronParser.Application.Providers
{
    public class BackslashCronParserProvider : ICronParserProvider
    {
        public List<string> Parse(ParseRequest parseRequest)
        {
            var allowedValues = parseRequest.AllowedValueRange.Split("-").Select(int.Parse).ToList();
            var store = new List<string>();
            var parts = parseRequest.Expression.Replace("*", allowedValues[0].ToString()).Split("/").Select(int.Parse).ToList();
            for (int i = parts[0]; i <= allowedValues[1]; i += parts[1])
            {
                store.Add(i.ToString());
            }
            return store;
        }
    }
}
