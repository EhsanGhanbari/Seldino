using System;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Seldino.Domain.GiftDeskAggregation;

namespace Seldino.Domain.ProductAggregation
{
    public class Product : EntityBase, IAggregateRoot
    {


        private ICollection<ProductTag> _productTags = new List<ProductTag>();
        private ICollection<ProductPicture> _productPictures = new List<ProductPicture>();
        private ICollection<ProductColor> _productColors = new List<ProductColor>();
        private ICollection<ProductSize> _productSizes = new List<ProductSize>();
        private ICollection<ProductAttribute> _productAttributes = new List<ProductAttribute>();
        private ICollection<ProductAttributeOption> _productAttributeOptions = new List<ProductAttributeOption>();
        private ICollection<User> _users = new List<User>();
        private ICollection<Store> _stores = new List<Store>();
        private ICollection<Discount> _discounts = new List<Discount>();
        private ICollection<GiftDesk> _giftDesks = new List<GiftDesk>();

        public string Name { get; set; }

        public string Slug { get; set; }

        public string OriginalName { get; set; }

        public bool IsInactive { get; set; }

        public bool IsUnavailable { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? OldDollarPrice { get; set; }

        public decimal? DollarPrice { get; set; }

        public bool NotExist { get; set; }

        public bool IsInSpecialState { get; set; }

        public string Brand { get; set; }

        public string SerializedTags { get; set; }

        public string SerializedColors { get; set; }

        public string SerializedSizes { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }

        public string Category { get; set; }

        public string MetKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public Guid? SpecialStateId { get; set; }

        public virtual ProductSpecialState ProductSpecialState { get; set; }

        public int VisitCount { get; set; }

        public virtual ICollection<ProductTag> ProductTags
        {
            get { return _productTags ?? (_productTags = new List<ProductTag>()); }
            set { _productTags = value; }
        }

        public virtual ICollection<ProductPicture> ProductPictures
        {
            get { return _productPictures ?? (_productPictures = new List<ProductPicture>()); }
            set { _productPictures = value; }
        }

        public virtual ICollection<ProductColor> ProductColors
        {
            get { return _productColors ?? (_productColors = new List<ProductColor>()); }
            set { _productColors = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }

        public virtual ICollection<ProductSize> ProductSizes
        {
            get { return _productSizes ?? (_productSizes = new Collection<ProductSize>()); }
            set { _productSizes = value; }
        }

        public virtual ICollection<ProductAttribute> ProductAttributes
        {
            get { return _productAttributes ?? (_productAttributes = new Collection<ProductAttribute>()); }
            set { _productAttributes = value; }
        }

        public virtual ICollection<ProductAttributeOption> ProductAttributeOptions
        {
            get { return _productAttributeOptions ?? (_productAttributeOptions = new Collection<ProductAttributeOption>()); }
            set { _productAttributeOptions = value; }
        }

        public virtual ICollection<ProductComment> ProductComments { get; set; }

        public virtual ICollection<Discount> Discounts
        {
            get { return _discounts ?? (_discounts = new Collection<Discount>()); }
            set { _discounts = value; }
        }

        public virtual ICollection<Store> Stores
        {
            get { return _stores ?? (_stores = new List<Store>()); }
            set { _stores = value; }
        }

        public virtual ICollection<GiftDesk> GiftDesks
        {
            get { return _giftDesks ?? (_giftDesks = new List<GiftDesk>()); }
            set { _giftDesks = value; }
        }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public void AddTag(ProductTag productTag)
        {
            _productTags.Add(productTag);
        }

        public void ClearTag()
        {
            _productTags.Clear();
        }

        public void AddPicture(ProductPicture productPicture)
        {
            _productPictures.Add(productPicture);
        }

        public void ClearPicture()
        {
            _productPictures.Clear();
        }

        public void AddColor(ProductColor productColor)
        {
            _productColors.Add(productColor);
        }

        public void ClearColor()
        {
            _productColors.Clear();
        }

        public void AddSize(ProductSize productSize)
        {
            _productSizes.Add(productSize);
        }

        public void ClearSize()
        {
            _productSizes.Clear();
        }

        protected override void Validate()
        {
            if (Category == null)
                AddBrokenRule(ProductBusinessRule.CategoryIsRequired);

            if (!Stores.Any())
                AddBrokenRule(ProductBusinessRule.StoreIsRequired);

            if (!ProductPictures.Any())
                AddBrokenRule(ProductBusinessRule.PictureIsRequired);

            if (!Users.Any())
                AddBrokenRule(ProductBusinessRule.UserIsRequired);
        }
    }
}
