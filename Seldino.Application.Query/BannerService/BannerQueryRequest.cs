using Seldino.CrossCutting.Paging;
using System;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.BannerService
{
    public class BannerQueryRequest : QueryRequest
    {
        public Guid BannerId { get; set; }

        public BannerQueryRequest(Guid bannerId)
        {
            BannerId = bannerId;
        }
    }


    public class BannersQueryRequest : PagingQueryRequest
    {
        public BannersQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public BannersQueryRequest(int pageIndex, int pageSize, Guid userId)
             : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            UserId = userId;
        }
    }

    public class AdvBannersQueryQueryRequest : QueryRequest
    {
        public AdvBannersQueryQueryRequest(int count)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}
