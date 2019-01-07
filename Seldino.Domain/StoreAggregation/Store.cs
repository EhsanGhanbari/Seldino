using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.DocumentAggregation;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.StoreAggregation.StoreComments;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.StoreAggregation
{
    public class Store : EntityBase, IAggregateRoot
    {

        private ICollection<StorePicture> _storePictures = new List<StorePicture>();
        private ICollection<User> _users = new List<User>();
        private ICollection<StoreComment> _storeComments = new List<StoreComment>();
        private ICollection<Discount> _discounts = new List<Discount>();
        private ICollection<Region> _supportedregions = new List<Region>();
        private ICollection<Area> _supportedAreas = new List<Area>();

        public string Name { get; set; }

        public bool IsInactive { get; set; }

        public string Phone { get; set; }

        public Guid? DocumentId { get; set; }

        public Document Document { get; set; }

        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Discount> Discounts
        {
            get { return _discounts ?? (_discounts = new Collection<Discount>()); }
            set { _discounts = value; }
        }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<StorePicture> Pictures
        {
            get { return _storePictures ?? (_storePictures = new Collection<StorePicture>()); }
            set { _storePictures = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new Collection<User>()); }
            set { _users = value; }
        }

        public virtual ICollection<StoreComment> StoreComments
        {
            get { return _storeComments ?? (_storeComments = new Collection<StoreComment>()); }
            set { _storeComments = value; }
        }

        public virtual ICollection<Region> SupportedRegions
        {
            get { return _supportedregions ?? (_supportedregions = new Collection<Region>()); }
            set { _supportedregions = value; }
        }

        public virtual ICollection<Area> SupportedAreas
        {
            get { return _supportedAreas ?? (_supportedAreas = new Collection<Area>()); }
            set { _supportedAreas = value; }
        }

        public void AddPicture(StorePicture picture)
        {
            _storePictures.Add(picture);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
