using System;

namespace Seldino.Application.Query.DiscountService
{
    public interface IDiscountQueryService
    {
        DiscountQueryResponse GetDiscountById(DiscountQueryRequest request);

        DiscountsQueryResponse GetAllDiscounts(DiscountQueryRequest request);

        DiscountsQueryResponse GetAllActiveDiscounts(DiscountQueryRequest request);

        DiscountsQueryResponse GetAllInactiveDiscounts(DiscountQueryRequest request);
    }
}
