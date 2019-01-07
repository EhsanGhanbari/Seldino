using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.DiscountAggregation
{
    public class Discount : EntityBase, IAggregateRoot
    {
        private ICollection<Product> _products = new List<Product>();
        private ICollection<Store> _stores = new List<Store>();
        private ICollection<ProductCategory> _productCategories = new List<ProductCategory>();
        private ICollection<ProductBrand> _productBrands = new List<ProductBrand>();
        private ICollection<ProductTag> _productTags = new List<ProductTag>();

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage
        /// </summary>
        public decimal Percentage { get; set; }

        /// <summary>
        /// Gets or sets the discount amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the discount start date and time
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the discount end date and time
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Discount is Running means that if it's already started or not 
        /// </summary>
        public bool Stopped { get; set; }

        /// <summary>
        /// Gets or sets the discount limitation
        /// </summary>
        public DiscountLimitation DiscountLimitation { get; set; }

        /// <summary>
        /// Type of discount
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Discount requires couponCode
        /// </summary>
        public bool RequiresCouponCode { get; set; }

        /// <summary>
        /// Coupon
        /// </summary>
        public string CouponCode { get; set; }


        public virtual ICollection<Product> Products
        {
            get { return _products ?? (_products = new List<Product>()); }
            set { _products = value; }
        }

        public virtual ICollection<Store> Stores
        {
            get { return _stores ?? (_stores = new List<Store>()); }
            set { _stores = value; }
        }

        public virtual ICollection<ProductCategory> ProductCategories
        {
            get { return _productCategories ?? (_productCategories = new List<ProductCategory>()); }
            set { _productCategories = value; }
        }

        public virtual ICollection<ProductBrand> ProductBrands
        {
            get { return _productBrands ?? (_productBrands = new List<ProductBrand>()); }
            set { _productBrands = value; }
        }

        public virtual ICollection<ProductTag> ProductTags
        {
            get { return _productTags ?? (_productTags = new List<ProductTag>()); }
            set { _productTags = value; }
        } 

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
