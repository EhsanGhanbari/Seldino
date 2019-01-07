using Seldino.CrossCutting.Enums;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Seldino.Domain.BannerAggregation
{
    public class Banner : EntityBase, IAggregateRoot
    {
        private ICollection<User> _users = new List<User>();

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid PictureId { get; set; }

        public virtual BannerPicture Picture { get; set; }

        public BannerType BannerType { get; set; }

        public decimal Fee { get; set; }

        public string Url { get; set; }

        public bool IsConfirmed { get; set; }

        public string Caption { get; set; }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }

        protected override void Validate()
        {
            if (StartDate >= EndDate)
                AddBrokenRule(BannerBusinessRule.StartDate);
        }
    }
}
