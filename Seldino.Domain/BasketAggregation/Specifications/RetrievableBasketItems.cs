using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BasketAggregation.Specifications
{
    public class RetrievableBasketItems : Specification<Basket>
    {
        public override bool IsSatisfiedBy(Basket candidate)
        {
            return candidate.IsDeleted == false;
        }

        public override Expression<Func<Basket, bool>> IsSatisfied()
        {
            return b => (b.IsDeleted == false);
        }
    }
}