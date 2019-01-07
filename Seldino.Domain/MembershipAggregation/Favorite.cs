using System.Collections.Generic;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.MembershipAggregation
{
    public class Favorite : EntityBase, IAggregateRoot
    {
        public ICollection<User> Users { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Store> Stores { get; set; }

        public string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
