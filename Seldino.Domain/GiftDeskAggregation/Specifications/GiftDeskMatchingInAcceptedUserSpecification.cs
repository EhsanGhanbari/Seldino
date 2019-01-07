using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.GiftDeskAggregation.Specifications
{
    public class GiftDeskMatchingInAcceptedUserSpecification:Specification<GiftDesk>
    {
        private readonly Guid _userId;

        public GiftDeskMatchingInAcceptedUserSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(GiftDesk candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<GiftDesk, bool>> IsSatisfied()
        {
            return p => p.AcceptedUsers.Any(c => c.Id == _userId);
        }
    }
}
