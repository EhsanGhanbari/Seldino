using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductColor : ValueObjectBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? IconId { get; set; }
        public virtual ProductIcon Icon { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
