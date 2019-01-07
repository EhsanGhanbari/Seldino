using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.OrderAggregation.Specifications
{
    public class OrderMatchingInOwnerSpecification : Specification<Order>
    {
        private readonly Guid _userId;

        public OrderMatchingInOwnerSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(Order candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Order, bool>> IsSatisfied()
        {
            if (_userId != Guid.Empty)
            {
                return p => p.User.Id == _userId;
            }

            return p => true;
        }
    }
}
