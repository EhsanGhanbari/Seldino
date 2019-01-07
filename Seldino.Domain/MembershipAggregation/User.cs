using Seldino.Domain.BannerAggregation;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.NotificationAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.BlogAggregation.BlogComments;
using Seldino.Domain.GiftDeskAggregation;

namespace Seldino.Domain.MembershipAggregation
{
    public class User : EntityBase, IAggregateRoot
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public Guid? ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public Guid? BasketId { get; set; }

        public virtual Basket Basket { get; set; }

        public string RoleName { get; set; }

        public virtual Role Role { get; set; }

        public ICollection<Banner> Banners { get; set; }

        public ICollection<Store> Stores { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Location> Locations { get; set; }

        public ICollection<BlogComment> BlogComments { get; set; }

        public Guid? GiftDeskId { get; set; }

        public virtual GiftDesk GiftDesk { get; set; }

        /// <summary>
        /// this is for accepted users
        /// </summary>
        public virtual ICollection<GiftDesk> GiftDesks { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
