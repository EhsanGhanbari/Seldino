using System;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.QueryModels;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.DiscountAggregation
{
    public interface IDiscountRepository : IRepositoryBase<Discount>
    {
        PagingQueryResponse<Discount> GetAllDiscounts(PagingQueryRequest query, Guid storeId);

        PagingQueryResponse<Discount> GetAllInactiveDiscounts(PagingQueryRequest query, Guid storeId);

        PagingQueryResponse<Discount> GetAllAactiveDiscounts(PagingQueryRequest query, Guid storeId);

        DiscountsCountQueryModel GetDiscountsCount(Guid storeId);
    }
}
