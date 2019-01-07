namespace Seldino.Application.Query.DashboardService
{
    public interface IDashboardQueryService
    {
        DashboardLayoutQueryResponse GetDashboardLayout(DashboardLayoutQueryRequest request);
    }
}
