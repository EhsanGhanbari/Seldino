using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductPicture : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
