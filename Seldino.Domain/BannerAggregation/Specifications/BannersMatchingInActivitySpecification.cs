using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BannerAggregation.Specifications
{
    public class BannersMatchingInActivitySpecification : Specification<Banner>
    {
        public override bool IsSatisfiedBy(Banner candidate)
        {
            return candidate.IsActive && (candidate.StartDate < DateTime.Now && candidate.EndDate > DateTime.Now);
        }

        public override Expression<Func<Banner, bool>> IsSatisfied()
        {
            return p => (p.IsActive && (p.StartDate < DateTime.Now && p.EndDate > DateTime.Now));
        }
    }
}