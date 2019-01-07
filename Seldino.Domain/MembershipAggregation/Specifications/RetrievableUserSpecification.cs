using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.MembershipAggregation.Specifications
{
    public class RetrievableUserSpecification : Specification<User>
    {
        private readonly string _keyword;

        public RetrievableUserSpecification(string keyword)
        {
            _keyword = keyword;
        }

        public override bool IsSatisfiedBy(User candidate)
        {
            if (!string.IsNullOrWhiteSpace(_keyword))
            {
                return candidate.IsDeleted == false && candidate.Email.Contains(_keyword);
            }

            return candidate.IsActive && candidate.IsDeleted == false;
        }

        public override Expression<Func<User, bool>> IsSatisfied()
        {
            if (!string.IsNullOrWhiteSpace(_keyword))
            {
                return p => (p.IsActive && p.IsDeleted == false && (p.Email.Contains(_keyword)));
            }

            return p => (p.IsActive && p.IsDeleted == false);
        }
    }
}