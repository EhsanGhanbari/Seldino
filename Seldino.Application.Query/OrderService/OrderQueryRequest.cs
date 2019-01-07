using System;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.OrderService
{
    public class OrderQueryRequest : QueryRequest
    {
        public OrderQueryRequest(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }

    public class OrdersQueryRequest : PagingQueryRequest
    {
        public OrdersQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public OrdersQueryRequest(int pageIndex, int pageSize, Guid userId)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            UserId = userId;
        }
    }


}
