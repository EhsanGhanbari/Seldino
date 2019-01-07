using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BannerAggregation.Specifications
{
    public class BannersMatchingInUnconfirmedSpecification : Specification<Banner>
    {
        public override bool IsSatisfiedBy(Banner candidate)
        {
            return candidate.IsConfirmed == false;
        }

        public override Expression<Func<Banner, bool>> IsSatisfied()
        {
            return p => (p.IsConfirmed == false);
        }
    }
}
