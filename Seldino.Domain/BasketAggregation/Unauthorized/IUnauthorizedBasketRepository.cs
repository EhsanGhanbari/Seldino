using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BasketAggregation.Unauthorized
{
    public interface IUnauthorizedBasketRepository : IRepositoryBase<UnauthorizedBasket>
    {
        UnauthorizedBasket GetBasketItems(Guid cookieId);

        UnauthorizedBasket GetBasketItems(PagingQueryRequest query, Guid cookieId);

        void ClearUnauthorizedBasket(IEnumerable<UnauthorizedBasketItem> baskets);
    }
}
