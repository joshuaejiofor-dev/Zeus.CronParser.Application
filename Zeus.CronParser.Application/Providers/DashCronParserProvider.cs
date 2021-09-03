using System.Collections.Generic;
using System.Linq;
using Zeus.CronParser.Application.Providers.Interfaces;
using Zeus.CronParser.Application.Requests;

namespace Zeus.CronParser.Application.Providers
{
    public class DashCronParserProvider : ICronParserProvider
    {
        public List<string> Parse(ParseRequest parseRequest)
        {
            var store = new List<string>();
            var parts = parseRequest.Expression.Split("-").Select(int.Parse).ToList();
            for (int i = parts[0]; i <= parts[1]; i++)
            {
                store.Add(i.ToString());
            }
            return store;
        }
    }
}
