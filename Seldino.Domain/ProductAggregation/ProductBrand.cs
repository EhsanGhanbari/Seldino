using System;
using System.Collections.Generic;
using Seldino.Domain.DiscountAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductBrand : ValueObjectBase
    {
        public string Name { get; set; }

        public Guid? IconId { get; set; }

        public virtual ProductIcon Icon { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } 

        public virtual  ICollection<Discount> Discounts { get; set; }
         
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
