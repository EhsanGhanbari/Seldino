
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.DiscountService
{
    public class DiscountQueryResponse : QueryResponse
    {
        public DiscountDto Discount { get; set; }
    }

    public class DiscountsQueryResponse : QueryResponse
    {
        public PagingQueryResponse<DiscountDto> Discounts { get; set; }
    }
}
