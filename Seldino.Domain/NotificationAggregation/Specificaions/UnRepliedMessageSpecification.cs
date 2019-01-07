using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.NotificationAggregation.Specificaions
{
    public class UnRepliedMessageSpecification : Specification<Message>
    {
        public Guid UserId { get; set; }

        public UnRepliedMessageSpecification(Guid userId)
        {
            UserId = userId;
        }

        public override bool IsSatisfiedBy(Message candidate)
        {
            return candidate.IsReplied == false;
        }

        public override Expression<Func<Message, bool>> IsSatisfied()
        {
            return m => m.IsReplied == false;
        }
    }
}