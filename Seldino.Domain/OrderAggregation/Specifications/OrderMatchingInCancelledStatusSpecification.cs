using System;
using System.Linq.Expressions;
using Seldino.CrossCutting.Enums;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.OrderAggregation.Specifications
{
    public class OrderMatchingInCancelledStatusSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Order, bool>> IsSatisfied()
        {
            var cancelled = OrderStatus.Cancelled;
            return c => c.Status == cancelled;
        }
    }
}
