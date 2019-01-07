using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BannerAggregation.Specifications
{
    public class RetrievableBannerSpecificaion : Specification<Banner>
    {
        public override bool IsSatisfiedBy(Banner candidate)
        {
            return candidate.IsDeleted == false;
        }

        public override Expression<Func<Banner, bool>> IsSatisfied()
        {
            return p => (p.IsDeleted == false);
        }
    }
}