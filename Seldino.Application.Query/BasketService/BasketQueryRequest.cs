using System;
using Seldino.CrossCutting.Paging;

namespace Seldino.Application.Query.BasketService
{
    public class BasketQueryRequest : PagingQueryRequest
    {
        public Guid CookieId { get; set; }

        public BasketQueryRequest(Guid userId)
        {
            UserId = userId;
        }

        public BasketQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
