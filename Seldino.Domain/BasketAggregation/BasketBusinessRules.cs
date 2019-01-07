using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BasketAggregation
{
    public class BasketBusinessRules
    {
        public static readonly BusinessRule DeliveryOptionRequired = new BusinessRule("DeliveryOption", "An order must have a valid delivery option.");

        public static readonly BusinessRule ItemInvalid = new BusinessRule("Item", "A basket cannot have any invalid items.");

        public static readonly BusinessRule BasketRequired = new BusinessRule("Basket", "A basket item must be related to a basket.");

        public static readonly BusinessRule ProductRequired = new BusinessRule("Product", "A basket item must be related to a product.");

        public static readonly BusinessRule QtyInvalid = new BusinessRule("Qty", "The quantity of a basket item cannot be negative.");
    }
}
