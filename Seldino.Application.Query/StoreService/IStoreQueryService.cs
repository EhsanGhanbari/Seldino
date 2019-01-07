using System;
namespace Seldino.Application.Query.StoreService
{
    public interface IStoreQueryService
    {
        StoreQueryResponse GetStoreById(StoreQueryRequest request);

        StoreQueryResponse GetStoreDetailById(StoreQueryRequest request);

        StoresQueryResponse GetStores(StoresQueryRequest queryRequest);

        StoresQueryResponse GetInactiveStores(StoresQueryRequest queryRequest);

        StoresQueryResponse GetBestSellingStores(StoresQueryRequest queryRequest);

        StoresQueryResponse GetDiscountedStores(StoresQueryRequest queryRequest);
    }
}
