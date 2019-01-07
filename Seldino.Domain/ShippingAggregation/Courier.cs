using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ShippingAggregation
{
    public class Courier : EntityBase
    {
        private readonly string _name;
        private readonly IEnumerable<ShippingService> _services;

        public Courier(string name, IEnumerable<ShippingService> services)
        {
            _name = name;
            _services = services;
        }

        public string Name { get; set; }

        public IEnumerable<ShippingService> Services => _services;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
