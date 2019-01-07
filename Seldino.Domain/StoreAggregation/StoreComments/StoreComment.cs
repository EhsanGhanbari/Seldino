using System;
using System.Collections.Generic;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.StoreAggregation.StoreComments
{
    public class StoreComment : EntityBase, IAggregateRoot
    {
        private ICollection<User> _users = new List<User>();
        private ICollection<Store> _store = new List<Store>();
        private ICollection<StoreComment> _storeComments = new List<StoreComment>();

        public string Body { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<StoreComment> ProductComments
        {
            get { return _storeComments ?? (_storeComments = new List<StoreComment>()); }
            set { _storeComments = value; }
        }

        public virtual ICollection<Store> Stores
        {
            get { return _store ?? (_store = new List<Store>()); }
            set { _store = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
