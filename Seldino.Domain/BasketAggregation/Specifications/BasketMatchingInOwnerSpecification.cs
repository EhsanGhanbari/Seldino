using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BasketAggregation.Specifications
{
    public class BasketMatchingInOwnerSpecification : Specification<Basket>
    {
        private readonly Guid _userId;

        public BasketMatchingInOwnerSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(Basket candidate)
        {
            return _userId == Guid.Empty || candidate.UserId == _userId;
        }

        public override Expression<Func<Basket, bool>> IsSatisfied()
        {
            if (_userId != Guid.Empty)
                return p => p.UserId == _userId;
            return p => true;
        }
    }
}
