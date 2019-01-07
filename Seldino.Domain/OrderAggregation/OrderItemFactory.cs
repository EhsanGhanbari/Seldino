using Seldino.Domain.ProductAggregation;

namespace Seldino.Domain.OrderAggregation
{
    public static class OrderItemFactory
    {
        public static OrderItem CreateItemFor(Product product, Order order, int qty)
        {
            return new OrderItem(product, order, qty);
        }
    }
}
