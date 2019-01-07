using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.DiscountAggregation.Specifications
{
    public class DiscountsMatchingInInactivitySpecification : Specification<Discount>
    {
        public override bool IsSatisfiedBy(Discount candidate)
        {
            return candidate.Stopped;
        }

        public override Expression<Func<Discount, bool>> IsSatisfied()
        {
            return d => d.Stopped;
        }
    }
}
