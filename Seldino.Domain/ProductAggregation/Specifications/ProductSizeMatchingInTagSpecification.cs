using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductSizeMatchingInTagSpecification : Specification<ProductSize>
    {
        public string Tag { get; set; }

        public string Keyword { get; set; }

        public ProductSizeMatchingInTagSpecification(string tag, string keyword)
        {
            Tag = tag;
            Keyword = keyword;
        }

        public override bool IsSatisfiedBy(ProductSize candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<ProductSize, bool>> IsSatisfied()
        {
            if (Tag == null)
            {
                return p => p.IsDeleted == false;
            }
            if (string.IsNullOrWhiteSpace(Keyword))
            {
                return p => p.ProductTags.Any(c => c.IsDeleted == false && c.Name == Tag);
            }

            return p => p.ProductTags.Any(c => c.IsDeleted == false && c.Name == Tag && p.Name.Contains(Keyword));
        }
    }
}