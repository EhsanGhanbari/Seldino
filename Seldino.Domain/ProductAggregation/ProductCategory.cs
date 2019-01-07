using System;
using System.Collections.Generic;
using Seldino.Domain.DiscountAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductCategory : ValueObjectBase
    {
        private ICollection<ProductTag> _productTags = new List<ProductTag>();
        private ICollection<ProductBrand> _productBrands= new List<ProductBrand>();
        private ICollection<ProductCategory> _productCategories = new List<ProductCategory>();
        private ICollection<ProductAttribute> _productAttributes = new List<ProductAttribute>();

        public string Name { get; set; }

        public Guid? IconId { get; set; }

        public virtual ProductIcon Icon { get; set; }

        public string ParentCategory { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories
        {
            get { return _productCategories ?? (_productCategories = new List<ProductCategory>()); }
            set { _productCategories = value; }
        }

        public virtual ICollection<ProductTag> ProductTags
        {
            get { return _productTags ?? (_productTags = new List<ProductTag>()); }
            set { _productTags = value; }
        }

        public virtual ICollection<ProductBrand> ProductBrands
        {
            get { return _productBrands ?? (_productBrands = new List<ProductBrand>()); }
            set { _productBrands = value; }
        }

        public virtual ICollection<ProductAttribute> ProductAttributes
        {
            get { return _productAttributes ?? (_productAttributes = new List<ProductAttribute>()); }
            set { _productAttributes = value; }
        }

        public ICollection<Discount> Discounts { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
