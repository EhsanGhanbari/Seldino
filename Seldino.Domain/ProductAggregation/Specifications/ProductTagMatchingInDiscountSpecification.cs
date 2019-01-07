using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductTagMatchingInDiscountSpecification : Specification<ProductTag>
    {
        private readonly Guid _storeId;

        public ProductTagMatchingInDiscountSpecification(Guid storeId)
        {
            _storeId = storeId;
        }

        public override bool IsSatisfiedBy(ProductTag candidate)
        {
            return candidate.Discounts.Any(c => c.Id == _storeId);
        }

        public override Expression<Func<ProductTag, bool>> IsSatisfied()
        {
            return s => s.Discounts.Any(c => c.Id == _storeId);
        }
    }
}
