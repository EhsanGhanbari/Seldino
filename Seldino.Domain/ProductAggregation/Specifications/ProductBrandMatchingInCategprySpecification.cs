using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductBrandMatchingInCategprySpecification : Specification<ProductBrand>
    {
        public string Category { get; set; }

        public string Keyword { get; set; }

        public ProductBrandMatchingInCategprySpecification(string category, string keyword)
        {
            Category = category;
            Keyword = keyword;
        }

        public override bool IsSatisfiedBy(ProductBrand candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<ProductBrand, bool>> IsSatisfied()
        {
            if (Category == null)
            {
                return p => p.IsDeleted == false;
            }

            if (string.IsNullOrWhiteSpace(Keyword))
            {
                return p => p.ProductCategories.Any(c => c.IsDeleted == false && c.Name == Category);
            }

            return p => p.ProductCategories.Any(c => c.IsDeleted == false && c.Name == Category && p.Name.Contains(Keyword));
        }
    }
}