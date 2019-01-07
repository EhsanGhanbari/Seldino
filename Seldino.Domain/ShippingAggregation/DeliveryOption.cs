using System;
using Seldino.CrossCutting.Enums;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ShippingAggregation
{
    public class DeliveryOption : EntityBase, IAggregateRoot, IDeliveryOption
    {
        public DeliveryOption(decimal freeDeliveryThreshold, decimal cost, ShippingService shippingService)
        {
            FreeDeliveryThreshold = freeDeliveryThreshold;
            Cost = cost;
            ShippingService = shippingService;
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            return total > FreeDeliveryThreshold ? 0 : Cost;
        }

        public decimal FreeDeliveryThreshold { get; set; }

        public decimal Cost { get; set; }

        public DeliveryTime DeliveryTime { get; set; }

        public Guid ShippingServiceId { get; set; }

        public ShippingService ShippingService { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
