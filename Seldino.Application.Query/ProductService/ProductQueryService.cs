using AutoMapper;
using Seldino.CrossCutting.Caching;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.ProductAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.ProductService
{
    internal class ProductQueryService : IProductQueryService
    {
        #region Constructor

        private readonly IProductRepository _productRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public ProductQueryService(
            IProductRepository productRepository, 
            ICacheManager cacheManager,
            ILogger logger)
        {
            _productRepository = productRepository;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        #endregion

        #region Product

        public ProductQueryResponse GetProductById(ProductQureyRequest request)
        {
            var response = new ProductQueryResponse();

            try
            {
                var product = _productRepository.GetById(request.ProductId);

                if (product == null)
                {
                    response.Message = ProductQueryMessage.ProductDoesNotFound;
                    return response;
                }

                response.Product = Mapper.Map<Product, ProductDto>(product);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductQueryResponse GetProductDetailById(ProductQureyRequest request)
        {
            var response = new ProductQueryResponse();

            try
            {
                var product = _productRepository.GetProductDetailById(request.ProductId);

                if (product == null)
                {
                    response.Message = ProductQueryMessage.ProductDoesNotFound;
                    return response;
                }

                response.Product = Mapper.Map<Product, ProductDto>(product);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetSpecialProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetSpecialProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoSpecialProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetInactiveProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetInactiveProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoSpecialProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetProductsBySize(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetProductsBySize(request, request.Category, request.Size);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;

        }

        public ProductsQueryResponse GetProductsByBrand(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetProductsByBrand(request, request.Category, request.Brand);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoProductFoundForBrand;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetLatestProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetLatestProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoLatestProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetSimiliarProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetSimilarProducts(request, request.ProductId);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoSimiliarProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetPopularProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetPopularProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoPopularProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetBestSellingProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();
            try
            {
                var products = _productRepository.GetBestSellingProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoBestSellingProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetMostvisitedProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();
            try
            {
                var products = _productRepository.GetMostvisitedProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoBestSellingProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetDiscountedProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetDiscouontedProducts(request);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoDiscountedProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse GetProductsByCategory(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();
            try
            {
                var products = _productRepository.GetProductsByCategory(request, request.Category);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoDiscountedProductFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;

        }

        public ProductsQueryResponse GetProductsByTag(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetProductsByTag(request, request.Category, request.Tag);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoProductFoundForTheTag;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                response.Message = QueryMessage.RetrievingFailed;
            }

            return response;
        }

        public ProductsQueryResponse SearchInProducts(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();
            try
            {
                var products = _productRepository.SearchInProducts(request, request.Category);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoResultFound;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return response;
        }

        #endregion

        #region Store

        public ProductsQueryResponse GetProductsByStore(ProductsQueryRequest request)
        {
            var response = new ProductsQueryResponse();

            try
            {
                var products = _productRepository.GetProductsByStore(request, request.StoreId);

                if (products == null)
                {
                    response.Message = ProductQueryMessage.NoProductFoundForTheStore;
                    return response;
                }

                response.Products = Mapper.Map<PagingQueryResponse<Product>, PagingQueryResponse<ProductDto>>(products);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        #endregion

        #region ProductColor

        public ProductColorQueryResponse GetProductColors(ProductColorQueryRequest request)
        {
            var response = new ProductColorQueryResponse();

            try
            {
                var productColorDto = _cacheManager.Retrieve<IList<ProductColorDto>>(CachingConstant.ProductBrands);

                if (productColorDto != null)
                {
                    response.ProductColors = string.IsNullOrWhiteSpace(request.Keyword)
                         ? response.ProductColors.ToList()
                         : response.ProductColors.Where(c => c.Name.Contains(request.Keyword)).ToList();
                }

                var productColors = _productRepository.GetProductColors(request.Keyword);
                productColorDto = Mapper.Map<IList<ProductColor>, IList<ProductColorDto>>(productColors);
                response.ProductColors = productColorDto;
                _cacheManager.Store(CachingConstant.ProductColors, productColorDto, CachingConstant.MemoryCacheTime);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        #endregion

        #region ProductBrand

        public ProductBrandQueryResponse GetProductBrandByValue(ProductBrandQueryRequest request)
        {
            var response = new ProductBrandQueryResponse();
            try
            {
                var productBrand = _productRepository.GetProductBrandByValue(request.Brand);

                if (productBrand == null)
                {
                    response.Message = ProductQueryMessage.NoProductFoundForTheBrand;
                    return response;
                }

                response.Brand = Mapper.Map<ProductBrand, ProductBrandDto>(productBrand);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        public ProductBrandsQueryResponse GetProductBrands(ProductsQueryRequest request)
        {
            var response = new ProductBrandsQueryResponse();

            try
            {
                var productBrandDto = _cacheManager.Retrieve<IList<ProductBrandDto>>(CachingConstant.ProductBrands);

                if (productBrandDto != null)
                {
                    response.Brands = string.IsNullOrWhiteSpace(request.Keyword)
                        ? productBrandDto.ToList()
                        : productBrandDto.Where(s => s.Name.Contains(request.Keyword)).ToList();
                }

                var brands = _productRepository.GetProductBrands(request.Keyword, request.Category);
                productBrandDto = Mapper.Map<IList<ProductBrand>, IList<ProductBrandDto>>(brands);
                response.Brands = productBrandDto;
                StoreAllProductBrandsInCache(request);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        private void StoreAllProductBrandsInCache(ProductsQueryRequest queryRequest)
        {
            var brands = _productRepository.GetProductBrands(queryRequest.Keyword, queryRequest.Category);
            var productSizeDto = Mapper.Map<IList<ProductBrand>, IList<ProductBrandDto>>(brands);
            _cacheManager.Store(CachingConstant.ProductBrands, productSizeDto, CachingConstant.MemoryCacheTime);
        }

        #endregion

        #region ProductCategory

        public ProductCategoryQueryResponse GetProductCategoryByValue(ProductCategoryQueryRequest request)
        {
            var response = new ProductCategoryQueryResponse();

            try
            {
                var productCategery = _productRepository.GetProductCategoryByValue(request.Category);

                if (productCategery == null)
                {
                    response.Message = ProductQueryMessage.ProductCategoryDoesNotFound;
                    return response;
                }

                response.Category = Mapper.Map<ProductCategory, ProductCategoryDto>(productCategery);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        public ProductCategoriesQueryResponse GetProductCategories(ProductCategoriesQueryRequest request)
        {
            var response = new ProductCategoriesQueryResponse();
            try
            {
                var productCategoryDto = _cacheManager.Retrieve<IList<ProductCategoryDto>>(CachingConstant.ProductCategories);

                if (productCategoryDto != null)
                {
                    response.Categories = string.IsNullOrWhiteSpace(request.Keyword)
                    ? productCategoryDto.ToList()
                    : productCategoryDto.Where(c => c.Name.Contains(request.Keyword)).ToList();
                }

                var productCategories = _productRepository.GetProductCategories(request.Keyword);
                productCategoryDto = Mapper.Map<IList<ProductCategory>, IList<ProductCategoryDto>>(productCategories);
                response.Categories = productCategoryDto;
                _cacheManager.Store(CachingConstant.ProductCategories, productCategoryDto, CachingConstant.MemoryCacheTime);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        #endregion

        #region ProductSize
        public ProductSizeQueryResponse GetProductSizes(ProductSizeQueryRequest request)
        {
            var response = new ProductSizeQueryResponse();

            try
            {
                var productSizeDto = _cacheManager.Retrieve<IList<ProductSizeDto>>(CachingConstant.ProductSizes);

                if (productSizeDto != null)
                {
                    response.Sizes = string.IsNullOrWhiteSpace(request.Keyword)
                        ? productSizeDto.ToList()
                        : productSizeDto.Where(s => s.Name.Contains(request.Keyword)).ToList();
                }

                var sizes = _productRepository.GetProductSizes(request.Keyword, request.Category);
                productSizeDto = Mapper.Map<IList<ProductSize>, IList<ProductSizeDto>>(sizes);
                response.Sizes = productSizeDto;
                StoreAllProductSizeInCache(request);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        private void StoreAllProductSizeInCache(ProductSizeQueryRequest request)
        {
            var sizes = _productRepository.GetProductSizes(request.Keyword, request.Category);
            var productSizeDto = Mapper.Map<IList<ProductSize>, IList<ProductSizeDto>>(sizes);
            _cacheManager.Store(CachingConstant.ProductSizes, productSizeDto, CachingConstant.MemoryCacheTime);
        }

        #endregion

        #region ProductAttribute

        public ProductAttributesQueryResponse GetProductAttributesByCategory(ProductAttributesQueryRequest request)
        {
            var response = new ProductAttributesQueryResponse();

            try
            {
                var productAttribute = _productRepository.GetProductAttributesByCategory(request.Category);
                response.Attributes = Mapper.Map<IList<ProductAttribute>, IList<ProductAttributeDto>>(productAttribute);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        #endregion

        #region ProductTag

        public ProductTagQueryResponse GetProductTagByValue(ProductTagQueryRequest request)
        {
            var response = new ProductTagQueryResponse();

            try
            {
                var productTag = _productRepository.GetProductTagByValue(request.Tag);
                response.Tag = Mapper.Map<ProductTag, ProductTagDto>(productTag);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        public ProductTagsQueryResponse GetPrductTags(ProductsQueryRequest queryRequest)
        {
            var response = new ProductTagsQueryResponse();

            try
            {
                var productTagDto = _cacheManager.Retrieve<IList<ProductTagDto>>(CachingConstant.PrductTags);

                if (productTagDto != null)
                {
                    response.Tags = string.IsNullOrWhiteSpace(queryRequest.Keyword)
                        ? productTagDto.ToList()
                        : productTagDto.Where(t => t.Name.Contains(queryRequest.Keyword)).ToList();
                }

                var productTag = _productRepository.GetProductTags(queryRequest.Keyword, queryRequest.Category);
                productTagDto = Mapper.Map<IList<ProductTag>, IList<ProductTagDto>>(productTag);
                response.Tags = productTagDto;
                StoreAllProductTagsInCache(queryRequest);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception.Message);
            }

            return response;
        }

        private void StoreAllProductTagsInCache(ProductsQueryRequest queryRequest)
        {
            var tags = _productRepository.GetProductTags(queryRequest.Keyword, queryRequest.Category);
            var productSizeDto = Mapper.Map<IList<ProductTag>, IList<ProductTagDto>>(tags);
            _cacheManager.Store(CachingConstant.PrductTags, productSizeDto, CachingConstant.MemoryCacheTime);
        }

        #endregion
    }
}
