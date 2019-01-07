using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.SettingService
{
    public class GetSettingQueryResponse : QueryResponse
    {
        public SettingDto Setting { get; set; }
    }
}
