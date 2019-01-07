using System.Collections.Generic;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.BannerService
{
    public class BannerQueryResponse : QueryResponse
    {
        public BannerDto Banner { get; set; }
    }

    public class BannersQueryResponse : QueryResponse
    {
        public PagingQueryResponse<BannerDto> Banners { get; set; }
    }

    public class AdvBannersQueryQueryResponse : QueryResponse
    {
        public IList<BannerDto> Banners { get; set; } 
    }
}
