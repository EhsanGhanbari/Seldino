using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Seldino.CrossCutting.Enums;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.OrderAggregation.Specifications;
using Seldino.Domain.QueryModels;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public Order GetOrder(Guid orderId)
        {
            return DataContext.Orders.SingleOrDefault(c => c.Id == orderId);
        }

        public PagingQueryResponse<Order> GetOrders(PagingQueryRequest query)
        {
            var specification = new OrderMatchingInOwnerSpecification(query.UserId);
            var totalCount = ReadOnlyDataContext.Orders.Where(specification.IsSatisfied());

            var result = new PagingQueryResponse<Order>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount.Count(),
                Result = DataContext.Orders
                    .Where(specification.IsSatisfied()).OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Order> GetInProcessOrders(PagingQueryRequest query)
        {
            var specification = new OrderMatchingInOwnerSpecification(query.UserId).And(new OrderMatchingInInProcessStatusSpecification());
            var totalCount = ReadOnlyDataContext.Orders.Where(specification.IsSatisfied());

            var result = new PagingQueryResponse<Order>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount.Count(),
                Result = DataContext.Orders
                    .Where(specification.IsSatisfied()).OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Order> GetPendingOrders(PagingQueryRequest query)
        {
            var specification = new OrderMatchingInOwnerSpecification(query.UserId);
            var totalCount = ReadOnlyDataContext.Orders.Where(specification.IsSatisfied());

            var result = new PagingQueryResponse<Order>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount.Count(),
                Result = DataContext.Orders
                    .Where(specification.IsSatisfied()).OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Order> GetCompletedOrder(PagingQueryRequest query)
        {
            var specification = new OrderMatchingInOwnerSpecification(query.UserId).And(new OrderMatchingInCompletedStatusSpecification());
            var totalCount = ReadOnlyDataContext.Orders.Where(specification.IsSatisfied());

            var result = new PagingQueryResponse<Order>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount.Count(),
                Result = DataContext.Orders
                    .Where(specification.IsSatisfied()).OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Order> GetCancelledOrders(PagingQueryRequest query)
        {
            var specification = new OrderMatchingInOwnerSpecification(query.UserId).And(new OrderMatchingInCancelledStatusSpecification());
            var totalCount = ReadOnlyDataContext.Orders.Where(specification.IsSatisfied());

            var result = new PagingQueryResponse<Order>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount.Count(),
                Result = DataContext.Orders
                    .Where(specification.IsSatisfied()).OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public IList<OrdersCountQueryModel> GetOrdersCount(Guid storeId)
        {
            //ToDo this query should be modified and pushed into linq to entity 

            var specification = new OrderMatchingInStoreSpecification(storeId);
            var query = ReadOnlyDataContext.Orders.Where(specification.IsSatisfied()).ToList();

            var model = new List<OrdersCountQueryModel>();

            if (query.Any())
            {
                model = new List<OrdersCountQueryModel>()
                {
                    new OrdersCountQueryModel
                    {
                        InProcess = query.Count(c => c.Status == OrderStatus.InProcess),
                        Completed = query.Count(c => c.Status == OrderStatus.Completed),
                        Cancelled = query.Count(c => c.Status == OrderStatus.Cancelled),
                       // StoreId = //ToDo store shoule has a relation with orders
                    }
                };

            }

            return model;
        }
    }
}
