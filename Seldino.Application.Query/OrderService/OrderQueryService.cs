using AutoMapper;
using Seldino.Domain.OrderAggregation;
using System;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.OrderService
{
    internal class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        public OrderQueryService(IOrderRepository orderRepository, ILogger logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public OrderQueryResponse GetOrderById(OrderQueryRequest request)
        {
            var response = new OrderQueryResponse();

            try
            {
                var order = _orderRepository.GetById(request.OrderId);
                response.Order = Mapper.Map<Order, OrderDto>(order);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }

        public OrdersQueryResponse GetOrders(OrdersQueryRequest request)
        {
            var response = new OrdersQueryResponse();

            try
            {
                var orders = _orderRepository.GetOrders(request);
                response.Orders = Mapper.Map<PagingQueryResponse<Order>, PagingQueryResponse<OrderDto>>(orders);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public OrdersQueryResponse GetInProcessOrders(OrdersQueryRequest request)
        {
            var response = new OrdersQueryResponse();

            try
            {
                var orders = _orderRepository.GetInProcessOrders(request);
                response.Orders = Mapper.Map<PagingQueryResponse<Order>, PagingQueryResponse<OrderDto>>(orders);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public OrdersQueryResponse GetPendingOrders(OrdersQueryRequest request)
        {
            var response = new OrdersQueryResponse();

            try
            {
                var orders = _orderRepository.GetPendingOrders(request);
                response.Orders = Mapper.Map<PagingQueryResponse<Order>, PagingQueryResponse<OrderDto>>(orders);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public OrdersQueryResponse GetCompletedOrders(OrdersQueryRequest request)
        {
            var response = new OrdersQueryResponse();

            try
            {
                var orders = _orderRepository.GetCompletedOrder(request);
                response.Orders = Mapper.Map<PagingQueryResponse<Order>, PagingQueryResponse<OrderDto>>(orders);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public OrdersQueryResponse GetCancelledOrders(OrdersQueryRequest request)
        {
            var response = new OrdersQueryResponse();

            try
            {
                var orders = _orderRepository.GetCompletedOrder(request);
                response.Orders = Mapper.Map<PagingQueryResponse<Order>, PagingQueryResponse<OrderDto>>(orders);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public OrderQueryResponse PursuitOrder(OrderQueryRequest request)
        {
            var response = new OrderQueryResponse();

            try
            {
                var order = _orderRepository.GetById(request.OrderId);
                response.Order = Mapper.Map<Order, OrderDto>(order);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }
    }
}
