using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ShippingAggregation
{
    public class ShippingService : EntityBase
    {
        public ShippingService(string code, string description, Courier courier)
        {
            Code = code;
            Description = description;
            Courier = courier;
        }
        
        public string Code { get; set; }

        public string Description { get; set; }

        public Guid CourierId { get; set; }

        public Courier Courier { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
