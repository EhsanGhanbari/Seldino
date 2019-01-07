using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductsMatchingInTagSpecification : Specification<Product>
    {
        public string Category { get; set; }
        public string Tag { get; set; }

        public ProductsMatchingInTagSpecification(string category, string tag)
        {
            Category = category;
            Tag = tag;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Category == Category && candidate.ProductTags.Any(t => t.Name == Tag);
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => (p.ProductTags.Any(c => c.Name == Tag) && p.Category == Category);
        }
    }
}