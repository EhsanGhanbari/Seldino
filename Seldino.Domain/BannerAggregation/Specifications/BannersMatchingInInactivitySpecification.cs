using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BannerAggregation.Specifications
{
    public class BannersMatchingInInactivitySpecification : Specification<Banner>
    {
        public override bool IsSatisfiedBy(Banner candidate)
        {
            return candidate.IsActive == false;
        }

        public override Expression<Func<Banner, bool>> IsSatisfied()
        {
            return p => (p.IsActive == false);
        }
    }
}