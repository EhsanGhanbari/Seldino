using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.NotificationAggregation.Specificaions
{
    public class RetrievableMessageSpecification : Specification<Message>
    {
        public override bool IsSatisfiedBy(Message candidate)
        {
            return candidate.IsDeleted == false;
        }

        public override Expression<Func<Message, bool>> IsSatisfied()
        {
            return m => m.IsDeleted == false;
        }
    }
}