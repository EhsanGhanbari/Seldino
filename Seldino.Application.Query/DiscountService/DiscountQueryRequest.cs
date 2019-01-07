using System;
using Seldino.CrossCutting.Paging;

namespace Seldino.Application.Query.DiscountService
{
    public class DiscountQueryRequest : PagingQueryRequest
    {
        public Guid DiscountId { get; set; }

        public Guid StoreId { get; set; }

        public DiscountQueryRequest(Guid discountId)
        {
            DiscountId = discountId;
        }

        public DiscountQueryRequest(int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public DiscountQueryRequest(string keyword, Guid discountId)
        {
            Keyword = keyword;
            DiscountId = discountId;
        }
    }
}
