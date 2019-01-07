using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;
using Seldino.Repository.QueryModels;

namespace Seldino.Domain.BannerAggregation
{
    public interface IBannerRepository : IRepositoryBase<Banner>
    {
        Banner GetBannerById(Guid bannerId);

        BannersCountQueryModel GetBannerCount(Guid userId);

        PagingQueryResponse<Banner> GetBanners(PagingQueryRequest queryRequest);

        PagingQueryResponse<Banner> GetInactiveBanners(PagingQueryRequest queryRequest);

        PagingQueryResponse<Banner> GetActiveBanners(PagingQueryRequest queryRequest);

        IList<Banner> GetActiveAdvBanners(int count);

        PagingQueryResponse<Banner> GetUnConfirmedBanners(PagingQueryRequest queryRequest);
    }
}
