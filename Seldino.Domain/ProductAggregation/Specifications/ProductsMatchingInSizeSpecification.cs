using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductsMatchingInSizeSpecification : Specification<Product>
    {
        public string Tag { get; set; }
        public string Size { get; set; }

        public ProductsMatchingInSizeSpecification(string tag, string size)
        {
            Tag = tag;
            Size = size;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.ProductTags.Any(c => c.Name == Tag) && candidate.ProductSizes.Any(c => c.Name == Size);
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => p.ProductTags.Any(c => c.Name == Tag) && p.ProductSizes.Any(c => c.Name == Size);
        }
    }
}