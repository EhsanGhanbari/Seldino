using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.StoreAggregation.Specifications
{
    public class StoreMatcingInDiscountSpecification: Specification<Store>
    {
        private readonly Guid _storeId;

        public StoreMatcingInDiscountSpecification(Guid storeId)
        {
            _storeId = storeId;
        }

        public override bool IsSatisfiedBy(Store candidate)
        {
            return candidate.Discounts.Any(c => c.Id == _storeId);
        }

        public override Expression<Func<Store, bool>> IsSatisfied()
        {
            return s => s.Discounts.Any(c => c.Id == _storeId);
        }
    }
}
