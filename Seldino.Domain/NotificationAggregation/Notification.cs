using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.NotificationAggregation
{
    public class Notification : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsActive { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
