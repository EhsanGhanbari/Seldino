using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using Seldino.Repository.QueryModels;

namespace Seldino.Domain.ProductAggregation
{
    public interface IProductRepository : IRepositoryBase<Product>
    {

        #region Product

        Product GetProductDetailById(Guid id);

        PagingQueryResponse<Product> GetProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetLatestProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetPopularProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetSimilarProducts(PagingQueryRequest query, Guid productId);

        PagingQueryResponse<Product> GetInactiveProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetSpecialProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetBestSellingProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetMostvisitedProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetDiscouontedProducts(PagingQueryRequest query);

        PagingQueryResponse<Product> GetDiscountedProductsOfACategory(PagingQueryRequest query, string category, Guid storeId);

        PagingQueryResponse<Product> GetDiscountedProductsOfATag(PagingQueryRequest query, Guid storeId);

        PagingQueryResponse<Product> GetDiscountedProductsOfABrand(PagingQueryRequest query, Guid storeId);

        PagingQueryResponse<Product> GetProductsByBrand(PagingQueryRequest query, string category, string brand);

        PagingQueryResponse<Product> GetProductsBySize(PagingQueryRequest query, string category, string size);

        PagingQueryResponse<Product> GetProductsByCategory(PagingQueryRequest query, string category);

        PagingQueryResponse<Product> GetProductsByTag(PagingQueryRequest query, string category, string tag);

        PagingQueryResponse<Product> SearchInProducts(PagingQueryRequest query, string category);

        ProducsCountQueryModel GetProducsCount(Guid userId);

        #endregion

        #region Product Store

        PagingQueryResponse<Product> GetProductsByStore(PagingQueryRequest query, Guid storeId);

        #endregion

        #region Product Category

        ProductCategory GetProductCategoryByValue(string category);

        IList<ProductCategory> GetProductCategories(string keyword);

        void DeleteProductCategory(string category);

        #endregion

        #region Product Tags

        ProductTag GetProductTagByValue(string tag);

        IList<ProductTag> GetProductTags(string category, string keyword);

        void DeleteProductTag(string tag);

        #endregion

        #region Product Brand

        ProductBrand GetProductBrandByValue(string brand);

        IList<ProductBrand> GetProductBrands(string category, string keyword);

        void DeleteProductBrand(string brand);

        #endregion

        #region Product Color

        ProductColor GetProductColorByValue(string color);

        IList<ProductColor> GetProductColors(string keyword);

        void DeleteProductColor(string color);

        #endregion

        #region Product Size

        ProductSize GetProductSizeByValue(string size);

        IList<ProductSize> GetProductSizes(string tag, string keyword);

        void DeleteProductSize(string size);

        #endregion

        #region Product Attribute

        IList<ProductAttribute> GetProductAttributesByCategory(string category);

        ProductAttribute GetProductAttribute(Guid attributeId);

        ProductAttributeOption GetProductAttributeOption(string optionName);

        #endregion
    }
}
