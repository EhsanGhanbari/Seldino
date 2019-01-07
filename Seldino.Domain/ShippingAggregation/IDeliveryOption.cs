namespace Seldino.Domain.ShippingAggregation
{
    public interface IDeliveryOption
    {
        decimal FreeDeliveryThreshold { get; }

        decimal Cost { get; }

        ShippingService ShippingService { get;  }

        decimal GetDeliveryChargeForBasketTotalOf(decimal total);
    }
}