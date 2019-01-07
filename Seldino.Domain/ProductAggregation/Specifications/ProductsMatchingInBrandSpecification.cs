using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductsMatchingInBrandSpecification : Specification<Product>
    {
        public string Category { get; set; }
        public string Brand { get; set; }

        public ProductsMatchingInBrandSpecification(string category, string brand)
        {
            Category = category;
            Brand = brand;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Category == Category && candidate.Brand == Brand;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => p.Category == Category && p.Brand == Brand;
        }
    }
}