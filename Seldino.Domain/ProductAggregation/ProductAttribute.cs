using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductAttribute : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }

        public ICollection<ProductAttributeOption> AttributeOptions { get; set; } 
        

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
