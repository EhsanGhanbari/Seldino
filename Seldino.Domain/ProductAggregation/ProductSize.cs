using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductSize : ValueObjectBase
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; } 

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
