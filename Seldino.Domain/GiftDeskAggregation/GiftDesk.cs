using System;
using System.Collections.Generic;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.GiftDeskAggregation
{
    public class GiftDesk : EntityBase, IAggregateRoot
    {

        /// <summary>
        /// Accepted users to see the gift card of the user
        /// </summary>
        public virtual ICollection<User> AcceptedUsers { get; set; }

        public bool IsPrivate { get; set; } 

        public ICollection<Product> Products { get; set; } 


        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
