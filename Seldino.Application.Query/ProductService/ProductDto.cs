using System;
using System.Collections.Generic;
using Seldino.Application.Query.MembershipService;
using Seldino.Application.Query.SettingService;
using Seldino.Domain.StoreAggregation;

namespace Seldino.Application.Query.ProductService
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string Slug { get; set; }

        public string OriginalName { get; set; }

        public bool IsInactive { get; set; }

        public bool IsUnAvailable { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal Price { get; set; }

        public decimal? DollarPrice { get; set; }

        public decimal? OldDollarPrice { get; set; }

        public string Description { get; set; }

        public string MetKeywords { get; set; }

        public bool NotExist { get; set; }

        public bool IsInSpecialState { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public ProductBrandDto ProductBrand { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

        public ProductSpecialStateDto ProductSpecialState { get; set; }

        public IList<ProductTagDto> ProductTags { get; set; }

        public IList<ProductPictureDto> ProductPictures { get; set; }

        public IList<ProductColorDto> ProductColors { get; set; }

        public IList<ProductSizeDto> ProductSizes { get; set; }

        public IList<ProductCommentDto> ProductComments { get; set; }

        public IList<Store> Stores { get; set; }
    }

    public class ProductCategoryDto
    {
        public string Name { get; set; }

        public ProductIconDto Icon { get; set; }

        public string Creator { get; set; }

        public IList<ProductBrandDto> ProductBrands { get; set; }

        public IList<ProductTagDto> ProductTags { get; set; }

        public IList<ProductAttributeDto> ProductAttributes { get; set; }
    }

    public class ProductBrandDto
    {
        public string Name { get; set; }

        public ProductIconDto Icon { get; set; }

        public string Creator { get; set; }
    }

    public class ProductTagDto
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public ProductIconDto Icon { get; set; }

        public IList<ProductSizeDto> ProductSizes { get; set; }
    }

    public class ProductColorDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Creator { get; set; }
    }

    public class ProductPictureDto
    {
        public Guid PictureId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string FullPath => Address + Name;
    }

    public class ProductSizeDto
    {
        public string Name { get; set; }

        public string Creator { get; set; }
    }

    public class ProductSpecialStateDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }
    }

    public class ProductAttributeDto
    {
        public Guid AttributeId { get; set; }

        public string Name { get; set; }

        public IList<ProductAttributeOpetionDto> AttributeOptions { get; set; }
    }

    public class ProductAttributeOpetionDto
    {
        public string Name { get; set; }
    }

    public class ProductCommentDto
    {
        public Guid CommentId { get; set; }

        public DateTime CreationDate { get; set; }

        public UserDto User { get; set; }

        public string Body { get; set; }

        public IList<ProductCommentDto> ProductComments { get; set; }
    }

    public class ProductIconDto
    {
        public Guid IconId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string FullPath => Address + Name;
    }
}
