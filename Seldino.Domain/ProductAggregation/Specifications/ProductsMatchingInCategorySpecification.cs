using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductsMatchingInCategorySpecification : Specification<Product>
    {
        public string Category { get; set; }

        public ProductsMatchingInCategorySpecification(string category)
        {
            Category = category;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Category == Category;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => p.Category == Category;
        }
    }
}