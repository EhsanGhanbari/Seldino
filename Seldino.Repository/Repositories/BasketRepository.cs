using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.BasketAggregation.Specifications;
using Seldino.Domain.BasketAggregation.Unauthorized;
using Seldino.Domain.ProductAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class BasketRepository : RepositoryBase<Basket>, IBasketRepository
    {
        public BasketRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public Basket GetBasketItems(PagingQueryRequest query)
        {
            //ToDo Paging
            var specification = new BasketMatchingInOwnerSpecification(query.UserId);
            return DataContext.Baskets.Where(specification.IsSatisfied())
                .Include(c => c.BasketItems)
                .Include(c => c.BasketItems.Select(r => r.Product))
                .SingleOrDefault();
        }

        public void AddBasketItem(BasketItem item)
        {
            DataContext.BasketItems.Add(item);
        }

        public Basket GetUserBasket(Guid userId)
        {
            return DataContext.Baskets.Include(c => c.BasketItems).SingleOrDefault(c => c.UserId == userId);
        }
    }

    internal class UnauthorizedBasketRepository : RepositoryBase<UnauthorizedBasket>, IUnauthorizedBasketRepository
    {
        public UnauthorizedBasketRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public UnauthorizedBasket GetBasketItems(Guid cookieId)
        {
            return DataContext.UnauthorizedBaskets.Where(d => d.CookieId == cookieId)
                  .Include(c => c.BasketItems)
                  .Include(c => c.BasketItems.Select(r => r.Product))
                  .SingleOrDefault();
        }

        public UnauthorizedBasket GetBasketItems(PagingQueryRequest query, Guid cookieId)
        {
            //ToDo Paging
            return DataContext.UnauthorizedBaskets.Where(d => d.CookieId == cookieId)
                .Include(c => c.BasketItems)
                .Include(c => c.BasketItems.Select(r => r.Product))
                .SingleOrDefault();
        }

        public void ClearUnauthorizedBasket(IEnumerable<UnauthorizedBasketItem> basketItems)
        {
            DataContext.UnauthorizedBasketItems.RemoveRange(basketItems);
        }
    }
}
