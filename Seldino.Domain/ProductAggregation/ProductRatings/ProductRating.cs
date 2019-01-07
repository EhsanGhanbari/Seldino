using System;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation.ProductRatings
{
    public class ProductRating : EntityBase, IAggregateRoot
    {
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Score Score { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
