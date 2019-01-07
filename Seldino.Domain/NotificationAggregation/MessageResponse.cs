using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.NotificationAggregation
{
    public class MessageResponse : EntityBase, IAggregateRoot
    {
        public string Body { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<MessageResponse> MessageResponses { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
