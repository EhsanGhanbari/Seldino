using System;
using Seldino.CrossCutting.Paging;

namespace Seldino.Application.Query.BannerService
{
    public interface IBannerQueryService
    {
        BannerQueryResponse GetBannerDetailById(BannerQueryRequest request);

        BannersQueryResponse GetBanners(BannersQueryRequest request);

        BannersQueryResponse GetInactiveBanners(BannersQueryRequest request);

        BannersQueryResponse GetActiveBanners(BannersQueryRequest request);

        AdvBannersQueryQueryResponse GetAdvBanners(AdvBannersQueryQueryRequest request);

        BannersQueryResponse GetUnConfirmedBanners(BannersQueryRequest request);
    }
}
