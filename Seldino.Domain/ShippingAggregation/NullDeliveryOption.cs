using System;

namespace Seldino.Domain.ShippingAggregation
{
    public class NullDeliveryOption : IDeliveryOption
    {
        public decimal FreeDeliveryThreshold => 0;

        public decimal Cost => 0;

        public ShippingService ShippingService
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            return 0;
        }
    }
}
