using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductCategoryMatchingInDiscountSpecification : Specification<ProductCategory>
    {
        private string _category;

        public ProductCategoryMatchingInDiscountSpecification(string category)
        {
            _category = category;
        }

        public override bool IsSatisfiedBy(ProductCategory candidate)
        {
            return candidate.ProductCategories.Any(c => c.Name == _category);
        }

        public override Expression<Func<ProductCategory, bool>> IsSatisfied()
        {
            return p => p.ProductCategories.Any(c => c.Name == _category);
        }
    }
}
