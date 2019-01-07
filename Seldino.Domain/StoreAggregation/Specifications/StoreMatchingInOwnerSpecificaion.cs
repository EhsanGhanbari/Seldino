using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.StoreAggregation.Specifications
{
    public class StoreMatchingInOwnerSpecificaion : Specification<Store>
    {
        private readonly Guid _userId;

        public StoreMatchingInOwnerSpecificaion(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(Store candidate)
        {
            return _userId == Guid.Empty || candidate.Users.Any(c => c.Id == _userId);
        }

        public override Expression<Func<Store, bool>> IsSatisfied()
        {
            if (_userId != Guid.Empty)
                return p => p.Users.Any(c => c.Id == _userId);
            return p => true;
        }
    }
}