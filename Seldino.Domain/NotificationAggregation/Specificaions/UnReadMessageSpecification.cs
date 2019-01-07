using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.NotificationAggregation.Specificaions
{
    public class UnReadMessageSpecification : Specification<Message>
    {
        public Guid UserId { get; set; }

        public UnReadMessageSpecification(Guid userId)
        {
            UserId = userId;
        }

        public override bool IsSatisfiedBy(Message candidate)
        {
            return candidate.IsRead == false;
        }

        public override Expression<Func<Message, bool>> IsSatisfied()
        {
            return m => m.IsRead == false;
        }
    }
}