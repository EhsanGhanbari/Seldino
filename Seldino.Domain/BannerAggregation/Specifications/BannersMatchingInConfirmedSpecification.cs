using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BannerAggregation.Specifications
{
    public class BannersMatchingInConfirmedSpecification : Specification<Banner>
    {
        public override bool IsSatisfiedBy(Banner candidate)
        {
            return candidate.IsConfirmed;
        }

        public override Expression<Func<Banner, bool>> IsSatisfied()
        {
            return p => (p.IsConfirmed);
        }
    }
}