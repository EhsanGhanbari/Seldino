using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class RetrievableProductSpecification : Specification<Product>
    {
        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.IsDeleted == false && candidate.IsInactive == false;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => (p.IsInactive == false && p.IsDeleted == false);
        }
    }
}