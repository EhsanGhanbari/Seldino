using System;
using Seldino.Infrastructure.Domain;
using Seldino.CrossCutting.Paging;

namespace Seldino.Domain.BasketAggregation
{
    public interface IBasketRepository : IRepositoryBase<Basket>
    {
        Basket GetBasketItems(PagingQueryRequest query);

        void AddBasketItem(BasketItem item);

        Basket GetUserBasket(Guid userId);
    }
}
