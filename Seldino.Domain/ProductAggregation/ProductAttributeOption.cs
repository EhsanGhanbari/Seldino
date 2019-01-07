using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductAttributeOption : ValueObjectBase
    {
        public string Name { get; set; }

        public ICollection<ProductAttribute> Attributes { get; set; } 

        public ICollection<Product> Products { get; set; } 

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
