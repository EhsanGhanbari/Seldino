using Seldino.Domain.ProductAggregation;

namespace Seldino.Domain.BasketAggregation
{
    public static class BasketItemFactory
    {
        public static BasketItem CreateItemFor(Product product, Basket basket)
        {
            return new BasketItem(product, basket, new Quantity(1));
        }
    }
}
