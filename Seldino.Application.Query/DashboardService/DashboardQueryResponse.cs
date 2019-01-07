using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.DashboardService
{
    public class DashboardLayoutQueryResponse : QueryResponse
    {
        public DashboardLayoutQueryResponse()
        {
            DashboardLayout = new DashboardLayoutDto();
        }

        public DashboardLayoutDto DashboardLayout { get; set; }
    }
}
