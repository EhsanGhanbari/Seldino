using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.OrderService
{
    public class OrderQueryResponse : QueryResponse
    {
        public OrderDto Order { get; set; }
    }

    public class OrdersQueryResponse: QueryResponse
    {
        public PagingQueryResponse<OrderDto> Orders { get; set; } 
    }
}
