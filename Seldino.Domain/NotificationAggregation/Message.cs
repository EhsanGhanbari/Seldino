using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.NotificationAggregation
{
    public class Message : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public bool IsReplied { get; set; }
        public NotificationMessageType NotificationMessageType { get; set; }
        public ICollection<MessageResponse> MessageResponses { get; set; }
        public ICollection<User> Users { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
