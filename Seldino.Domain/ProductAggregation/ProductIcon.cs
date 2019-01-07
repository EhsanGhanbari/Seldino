using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductIcon : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}