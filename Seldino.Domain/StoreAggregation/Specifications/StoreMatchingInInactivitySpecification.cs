using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.StoreAggregation.Specifications
{
    public class StoreMatchingInInactivitySpecification : Specification<Store>
    {
        public override bool IsSatisfiedBy(Store candidate)
        {
            return candidate.IsDeleted == false && candidate.IsInactive;
        }

        public override Expression<Func<Store, bool>> IsSatisfied()
        {
            return p => (p.IsInactive && p.IsDeleted == false);
        }
    }
}