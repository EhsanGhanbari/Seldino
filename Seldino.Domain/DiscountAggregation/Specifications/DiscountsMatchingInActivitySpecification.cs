using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.DiscountAggregation.Specifications
{
    public class DiscountsMatchingInActivitySpecification : Specification<Discount>
    {
        public Guid UserId { get; set; }

        public override bool IsSatisfiedBy(Discount candidate)
        {
            return candidate.Stopped == false;
        }

        public override Expression<Func<Discount, bool>> IsSatisfied()
        {
            return discount =>  discount.Stopped == false;
        }
    }
}