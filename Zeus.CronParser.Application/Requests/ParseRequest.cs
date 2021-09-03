using System.Collections.Generic;

namespace Zeus.CronParser.Application.Requests
{
    public class ParseRequest
    {
        public string Expression { get; set; } 
        public List<string> AllowedSpecialChars { get; set; }
        public string AllowedValueRange { get; set; }
    }
}
