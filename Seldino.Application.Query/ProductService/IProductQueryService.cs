using System;

namespace Seldino.Application.Query.ProductService
{
    public interface IProductQueryService
    {

        #region Product

        ProductQueryResponse GetProductById(ProductQureyRequest request);

        ProductQueryResponse GetProductDetailById(ProductQureyRequest request);

        ProductsQueryResponse GetSpecialProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetInactiveProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetProductsByCategory(ProductsQueryRequest request);

        ProductsQueryResponse GetProductsByTag(ProductsQueryRequest request);

        ProductsQueryResponse GetProductsBySize(ProductsQueryRequest request);

        ProductsQueryResponse GetProductsByBrand(ProductsQueryRequest request);

        ProductsQueryResponse GetLatestProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetSimiliarProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetDiscountedProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetPopularProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetBestSellingProducts(ProductsQueryRequest request);

        ProductsQueryResponse GetMostvisitedProducts(ProductsQueryRequest request);

        ProductsQueryResponse SearchInProducts(ProductsQueryRequest request);

        #endregion

        #region Store

        ProductsQueryResponse GetProductsByStore(ProductsQueryRequest request);

        #endregion

        #region ProductColor

        ProductColorQueryResponse GetProductColors(ProductColorQueryRequest request);

        #endregion

        #region ProductBrand

        ProductBrandQueryResponse GetProductBrandByValue(ProductBrandQueryRequest request);

        ProductBrandsQueryResponse GetProductBrands(ProductsQueryRequest request);

        #endregion

        #region ProductCategory

        ProductCategoryQueryResponse GetProductCategoryByValue(ProductCategoryQueryRequest request);

        ProductCategoriesQueryResponse GetProductCategories(ProductCategoriesQueryRequest request);

        #endregion

        #region ProductSize

        ProductSizeQueryResponse GetProductSizes(ProductSizeQueryRequest request);

        #endregion

        #region ProductAttribtue

        ProductAttributesQueryResponse GetProductAttributesByCategory(ProductAttributesQueryRequest request);

        #endregion

        #region ProductTag

        ProductTagQueryResponse GetProductTagByValue(ProductTagQueryRequest request);

        ProductTagsQueryResponse GetPrductTags(ProductsQueryRequest request);

        #endregion      
    }
}
