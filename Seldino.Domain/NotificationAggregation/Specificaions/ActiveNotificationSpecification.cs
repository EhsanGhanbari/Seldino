using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.NotificationAggregation.Specificaions
{
    public class ActiveNotificationSpecification : Specification<Notification>
    {
        public override bool IsSatisfiedBy(Notification candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Notification, bool>> IsSatisfied()
        {
            return p => p.IsActive;
        }
    }
}
