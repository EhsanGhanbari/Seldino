using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.QueryModels;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.OrderAggregation
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Order GetOrder(Guid orderId);

        PagingQueryResponse<Order> GetOrders(PagingQueryRequest query);

        PagingQueryResponse<Order> GetInProcessOrders(PagingQueryRequest query);

        PagingQueryResponse<Order> GetPendingOrders(PagingQueryRequest query);

        PagingQueryResponse<Order> GetCompletedOrder(PagingQueryRequest query);

        PagingQueryResponse<Order> GetCancelledOrders(PagingQueryRequest query);

        IList<OrdersCountQueryModel> GetOrdersCount(Guid storeId);
    }
}
