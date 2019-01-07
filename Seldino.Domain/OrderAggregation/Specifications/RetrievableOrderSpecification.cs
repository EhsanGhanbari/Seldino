using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.OrderAggregation.Specifications
{
    public class RetrievableOrderSpecification:Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Order, bool>> IsSatisfied()
        {
            return c => c.IsDeleted == false;
        }
    }
}
