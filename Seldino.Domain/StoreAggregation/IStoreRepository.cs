using System;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.StoreAggregation
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        Store GetStoreDetailById(Guid storeId);

        PagingQueryResponse<Store> GetBestSellingStores(PagingQueryRequest query);

        PagingQueryResponse<Store> GetDiscountedStores(PagingQueryRequest query);

        PagingQueryResponse<Store> GetStores(PagingQueryRequest query);

        PagingQueryResponse<Store> GetInactiveStores(PagingQueryRequest query);
    }
}
