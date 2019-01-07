using System;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.DashboardService
{
    public class DashboardLayoutQueryRequest : QueryRequest
    {
        public DashboardLayoutQueryRequest(Guid userId)
        {
            UserId = userId;
        }

        public Guid StoreId { get; set; }
    }
}
