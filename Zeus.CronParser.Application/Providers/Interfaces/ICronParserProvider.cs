using System.Collections.Generic;
using Zeus.CronParser.Application.Requests;

namespace Zeus.CronParser.Application.Providers.Interfaces
{
    public interface ICronParserProvider
    {
        List<string> Parse(ParseRequest parseRequest);
    }
}
