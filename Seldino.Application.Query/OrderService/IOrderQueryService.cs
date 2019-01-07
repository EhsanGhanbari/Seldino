using System;

namespace Seldino.Application.Query.OrderService
{
    public interface IOrderQueryService
    {
        OrderQueryResponse GetOrderById(OrderQueryRequest request);

        OrdersQueryResponse GetOrders(OrdersQueryRequest request);

        OrdersQueryResponse GetInProcessOrders(OrdersQueryRequest request);

        OrdersQueryResponse GetPendingOrders(OrdersQueryRequest request);

        OrdersQueryResponse GetCompletedOrders(OrdersQueryRequest request);

        OrdersQueryResponse GetCancelledOrders(OrdersQueryRequest request);

        OrderQueryResponse PursuitOrder(OrderQueryRequest request);
    }
}
