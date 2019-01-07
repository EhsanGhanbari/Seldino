using System;
using System.Linq.Expressions;
using Seldino.CrossCutting.Enums;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.OrderAggregation.Specifications
{
    public class OrderMatchingInInProcessStatusSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Order, bool>> IsSatisfied()
        {
            var inProcess = OrderStatus.InProcess;
            return c => c.Status == inProcess;
        }
    }
}
