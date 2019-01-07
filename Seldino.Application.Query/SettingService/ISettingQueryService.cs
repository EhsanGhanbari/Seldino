namespace Seldino.Application.Query.SettingService
{
    public interface ISettingQueryService
    {
        GetSettingQueryResponse GetCachedSetting(GetSettingQueryRequest request);     
    }
}
