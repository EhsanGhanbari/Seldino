using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.BannerAggregation.Specifications
{
    public class BannerMatchingInOwnerSpecification : Specification<Banner>
    {
        private readonly Guid _userId;

        public BannerMatchingInOwnerSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(Banner candidate)
        {
            return _userId != Guid.Empty || candidate.Users.Any(c => c.Id == _userId);
        }

        public override Expression<Func<Banner, bool>> IsSatisfied()
        {
            if (_userId != Guid.Empty)
                return p => p.Users.Any(c => c.Id == _userId);
            return p => true;
        }
    }
}