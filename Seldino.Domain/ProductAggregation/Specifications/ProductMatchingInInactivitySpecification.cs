using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductMatchingInInactivitySpecification : Specification<Product>
    {
        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.IsDeleted == false && candidate.IsInactive;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => (p.IsInactive && p.IsDeleted == false && p.IsInactive);
        }
    }
}