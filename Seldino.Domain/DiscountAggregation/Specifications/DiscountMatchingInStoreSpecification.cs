using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.DiscountAggregation.Specifications
{
    public class DiscountMatchingInStoreSpecification : Specification<Discount>
    {
        private readonly Guid _storeId;

        public DiscountMatchingInStoreSpecification(Guid storeId)
        {
            _storeId = storeId;
        }

        public override bool IsSatisfiedBy(Discount candidate)
        {
            return _storeId == Guid.Empty || candidate.Stores.Any(c => c.Id == _storeId);
        }

        public override Expression<Func<Discount, bool>> IsSatisfied()
        {
            if (_storeId != Guid.Empty)
                return p => p.Stores.Any(c => c.Id == _storeId);
            return p => true;
        }
    }
}
