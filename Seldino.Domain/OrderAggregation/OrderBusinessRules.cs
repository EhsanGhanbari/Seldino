using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.OrderAggregation
{
    public class OrderBusinessRules
    {
        public static readonly BusinessRule ProductHasBeenDeleted = new BusinessRule("IsDeleted", OrderBusinessRulesMessages.ProductHasBeenDeleted);
        public static readonly BusinessRule OrderRequired = new BusinessRule("OrderRequired", "An order item must be associated with an order.");
        public static readonly BusinessRule PriceNonNegative = new BusinessRule("Price", OrderBusinessRulesMessages.OrderMustHaveNonNegativePrice);
        public static readonly BusinessRule QtyNonNegative = new BusinessRule("Quantity", "An order item must have a positive qty value.");
        public static readonly BusinessRule ProductRequired = new BusinessRule("Product", OrderBusinessRulesMessages.OrderMustAssociatedWithProduct);
        public static readonly BusinessRule CreatedDateRequired = new BusinessRule("CreatedDate", OrderBusinessRulesMessages.OrderMustHaveACreationDate);
        public static readonly BusinessRule PaymentTransactionIdRequired = new BusinessRule("PaymentTransactionId", "If an order is set as paid it must have a corresponding payment transaction id.");
        public static readonly BusinessRule CustomerRequired = new BusinessRule("Customer", OrderBusinessRulesMessages.OrderMustAssociatedWithCustomer);
        public static readonly BusinessRule DeliveryAddressRequired = new BusinessRule("DeliveryAddress", OrderBusinessRulesMessages.OrderMustHaveDeliveryAddress);
        public static readonly BusinessRule ItemsRequired = new BusinessRule("Items", OrderBusinessRulesMessages.OrderMustHaveAnItem);
        public static readonly BusinessRule ShippingServiceRequired = new BusinessRule("ShippingService", OrderBusinessRulesMessages.ShippingServiceIsRequiredForOrder);
    }
}
