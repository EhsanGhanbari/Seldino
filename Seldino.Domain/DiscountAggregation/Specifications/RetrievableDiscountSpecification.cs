using Seldino.Infrastructure.Specification;
using System;
using System.Linq.Expressions;

namespace Seldino.Domain.DiscountAggregation.Specifications
{
    public class RetrievableDiscountSpecification: Specification<Discount>
    {
        public override bool IsSatisfiedBy(Discount candidate)
        {
            return candidate.IsDeleted == false;
        }
        
        public override Expression<Func<Discount, bool>> IsSatisfied()
        {
            return d => d.IsDeleted == false;
        }
    }
}
