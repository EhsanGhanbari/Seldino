using Seldino.Domain.ProductAggregation;

namespace Seldino.Domain.BasketAggregation.Unauthorized
{
    public class UnauthorizedBasketItemFactory
    {
        public static UnauthorizedBasketItem CreateItemFor(Product product, UnauthorizedBasket basket)
        {
            return new UnauthorizedBasketItem(product, basket, new Quantity(1));
        }
    }
}
