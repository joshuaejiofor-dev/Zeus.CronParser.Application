using Zeus.CronParser.Application.Providers.Interfaces;

namespace Zeus.CronParser.Application.Factory.Interfaces
{
    public interface ICronParserProviderFactory
    {
        ICronParserProvider Create(string specialChar);
    }
}
