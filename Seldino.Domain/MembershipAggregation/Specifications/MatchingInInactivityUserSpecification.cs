using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.MembershipAggregation.Specifications
{
    public class MatchingInInactivityUserSpecification : Specification<User>
    {
        private readonly string _keyword;

        public MatchingInInactivityUserSpecification(string keyword)
        {
            _keyword = keyword;
        }

        public override bool IsSatisfiedBy(User candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<User, bool>> IsSatisfied()
        {
            if (!string.IsNullOrWhiteSpace(_keyword))
            {
                return p => (p.IsActive == false & p.IsDeleted == false && p.Email.Contains(_keyword));
            }

            return p => (p.IsActive == false & p.IsDeleted == false);
        }
    }
}