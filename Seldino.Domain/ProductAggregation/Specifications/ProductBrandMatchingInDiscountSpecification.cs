using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductBrandMatchingInDiscountSpecification : Specification<ProductBrand>
    {
        public string _brand;

        public ProductBrandMatchingInDiscountSpecification(string brand)
        {
            _brand = brand;
        }

        public override bool IsSatisfiedBy(ProductBrand candidate)
        {
            return candidate.Discounts.Any(c => c.Name == _brand);
        }

        public override Expression<Func<ProductBrand, bool>> IsSatisfied()
        {
            return p => p.Discounts.Any(c => c.Name == _brand);
        }
    }
}
