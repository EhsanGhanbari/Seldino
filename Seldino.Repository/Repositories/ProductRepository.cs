using Seldino.CrossCutting.Paging;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.ProductAggregation.ProductRatings;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Seldino.Domain.ProductAggregation.Specifications;
using Seldino.Repository.QueryModels;

namespace Seldino.Repository.Repositories
{
    #region ProductRepository
    internal class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        #region Constructor

        public ProductRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #endregion

        #region Product

        public Product GetProductDetailById(Guid id)
        {
            return DataContext.Products.Where(p => p.Id == id)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductColors)
                .Include(p => p.Discounts)
                .Include(p => p.Stores)
                .Include(p => p.ProductComments)
                .Include(p => p.ProductAttributes)
                .Include(p => p.ProductAttributeOptions)
                .Include(p => p.ProductAttributes.Select(c => c.AttributeOptions))
                .SingleOrDefault();
        }

        public PagingQueryResponse<Product> GetProducts(PagingQueryRequest query)
        {
            var specification = new RetrievableProductSpecification().And(new ProductMatchingInOwnerSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.Stores)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .Include(c => c.ProductComments)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetLatestProducts(PagingQueryRequest query)
        {
            var specification = new RetrievableProductSpecification();
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };
          
            return result;
        }

        public PagingQueryResponse<Product> GetPopularProducts(PagingQueryRequest query)
        {
            var specification = new RetrievableProductSpecification();
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetSimilarProducts(PagingQueryRequest query, Guid productId)
        {
            var specification = new RetrievableProductSpecification().And(new SimiliarProductSpecification(productId));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetInactiveProducts(PagingQueryRequest query)
        {
            var specification = new ProductMatchingInInactivitySpecification().And(new ProductMatchingInOwnerSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetSpecialProducts(PagingQueryRequest query)
        {
            var specification = new RetrievableProductSpecification().And(new ProductMatchingInSpecialStateSpecification());
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetBestSellingProducts(PagingQueryRequest query)
        {
            //ToDo Business
            var specification = new RetrievableProductSpecification();
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetMostvisitedProducts(PagingQueryRequest query)
        {
            var specification = new RetrievableProductSpecification();
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.VisitCount)
                    .Include(c => c.ProductPictures)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetDiscouontedProducts(PagingQueryRequest query)
        {
            //ToDo
            var specification = new RetrievableProductSpecification();
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetDiscountedProductsOfACategory(PagingQueryRequest query, string category, Guid storeId)
        {
            var specification =
                new RetrievableProductSpecification();
            //  .And(new DiscountsMatchingInCategorySpecification(category));

            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products.
                    Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetDiscountedProductsOfATag(PagingQueryRequest query, Guid storeId)
        {
            throw new NotImplementedException();
        }

        public PagingQueryResponse<Product> GetDiscountedProductsOfABrand(PagingQueryRequest query, Guid storeId)
        {
            throw new NotImplementedException();
        }

        public PagingQueryResponse<Product> GetProductsByBrand(PagingQueryRequest query, string category, string brand)
        {
            var specification = new RetrievableProductSpecification().And(new ProductsMatchingInBrandSpecification(category, brand));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products.
                    Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetProductsBySize(PagingQueryRequest query, string category, string size)
        {
            var specification = new RetrievableProductSpecification().And(new ProductsMatchingInSizeSpecification(category, size));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(p => p.ProductSizes.Where(c => c.Name == size))
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(f => f.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetProductsByCategory(PagingQueryRequest query, string category)
        {
            var specification = new RetrievableProductSpecification().And(new ProductsMatchingInCategorySpecification(category));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products.
                     Where(specification.IsSatisfied())
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductTags)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .Include(c => c.ProductCategory)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> GetProductsByTag(PagingQueryRequest query, string category, string tag)
        {
            var specification = new RetrievableProductSpecification().And(new ProductsMatchingInTagSpecification(category, tag));
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(p => p.ProductTags)
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(f => f.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Product> SearchInProducts(PagingQueryRequest query, string category)
        {
            var specification = new RetrievableProductSpecification();
            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = string.IsNullOrWhiteSpace(query.Keyword)
                ? DataContext.Products.Where(t => t.IsDeleted == false
                    && t.ProductCategory.Name == category).ToList()

                   : DataContext.Products.Where(t => t.IsDeleted == false && t.Name.Contains(query.Keyword)
                     && t.ProductCategory.Name == category).ToList()
                     .OrderByDescending(f => f.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public ProducsCountQueryModel GetProducsCount(Guid userId)
        {
            var specification = new RetrievableProductSpecification().And(new ProductMatchingInOwnerSpecification(userId));
            var query = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).GroupBy(d => d.IsInactive).Select(d => new
            {
                d.Key,
                Count = d.Count()
            });

            var model = new ProducsCountQueryModel();

            if (query.Any())
            {
                model.Active = query.SingleOrDefault(x => x.Key == false).Count;
                model.Inactive = query.SingleOrDefault(x => x.Key).Count;
            }

            return model;
        }


        #endregion

        #region ProductStore
        public PagingQueryResponse<Product> GetProductsByStore(PagingQueryRequest query, Guid storeId)
        {
            var specification =
                new RetrievableProductSpecification()
                .And(new ProductMatchingInOwnerSpecification(query.UserId)
                .And(new ProductMatchingInStoreSpecification(storeId)));

            var totalCount = ReadOnlyDataContext.Products.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Product>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Products
                    .Where(specification.IsSatisfied())
                    .Include(p => p.ProductTags)
                    .Include(c => c.ProductPictures)
                    .Include(c => c.ProductBrand)
                    .Include(c => c.ProductSizes)
                    .Include(c => c.ProductColors)
                    .OrderByDescending(f => f.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        #endregion

        #region ProductCategory

        public ProductCategory GetProductCategoryByValue(string category)
        {
            return DataContext.ProductCategories.SingleOrDefault(pc => pc.Name == category);
        }

        public IList<ProductCategory> GetProductCategories(string keyword)
        {
            return string.IsNullOrWhiteSpace(keyword)
                ? DataContext.ProductCategories.
                    Where(t => t.IsDeleted == false).
                    Include(c => c.ProductBrands).
                    Include(c => c.ProductTags).
                    Include(c => c.Icon).ToList()
                : DataContext.ProductCategories.
                    Where(t => t.IsDeleted == false && t.Name.Contains(keyword)).
                    Include(c => c.ProductBrands).
                    Include(c => c.ProductTags).
                    Include(c => c.Icon).ToList();
        }

        public void DeleteProductCategory(string category)
        {
            var result = DataContext.ProductCategories.SingleOrDefault(b => b.Name == category);
            if (result != null) result.IsDeleted = true;
            DataContext.Entry(result).State = EntityState.Modified;
        }

        #endregion

        #region ProductTag

        public ProductTag GetProductTagByValue(string color)
        {
            return DataContext.ProductTags.SingleOrDefault(pt => pt.Name == color);
        }

        public IList<ProductTag> GetProductTags(string category, string keyword)
        {
            var specification = new ProductTagMatchingInCategprySpecification(category, keyword);
            return DataContext.ProductTags.Where(specification.IsSatisfied()).ToList();
        }

        public PagingQueryResponse<ProductTag> GetDiscountedTags(PagingQueryRequest query, Guid storeId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductTag(string tag)
        {
            var result = DataContext.ProductTags.SingleOrDefault(b => b.Name == tag);
            if (result != null) result.IsDeleted = true;
            DataContext.Entry(result).State = EntityState.Modified;
        }

        #endregion

        #region ProductBrand

        public ProductBrand GetProductBrandByValue(string brand)
        {
            return DataContext.ProductBrands.SingleOrDefault(pb => pb.Name == brand);
        }

        public IList<ProductBrand> GetProductBrands(string category, string keyword)
        {
            var specification = new ProductBrandMatchingInCategprySpecification(category, keyword);
            return DataContext.ProductBrands.Where(specification.IsSatisfied()).ToList();
        }

        public void DeleteProductBrand(string brand)
        {
            var result = DataContext.ProductBrands.SingleOrDefault(b => b.Name == brand);
            if (result != null) result.IsDeleted = true;
            DataContext.Entry(result).State = EntityState.Modified;
        }

        #endregion

        #region ProductColor
        public ProductColor GetProductColorByValue(string color)
        {
            return DataContext.ProductColors.SingleOrDefault(pt => pt.Name == color);
        }

        public IList<ProductColor> GetProductColors(string keyword)
        {
            return string.IsNullOrWhiteSpace(keyword)
                ? DataContext.ProductColors.Where(t => t.IsDeleted == false).ToList()
                : DataContext.ProductColors.Where(t => t.IsDeleted == false && t.Name.Contains(keyword)).ToList();
        }

        public void DeleteProductColor(string color)
        {
            var result = DataContext.ProductColors.SingleOrDefault(b => b.Name == color);
            if (result != null) result.IsDeleted = true;
            DataContext.Entry(result).State = EntityState.Modified;
        }

        #endregion

        #region ProductSize

        public ProductSize GetProductSizeByValue(string size)
        {
            return DataContext.ProductSizes.SingleOrDefault(pt => pt.Name == size);
        }

        public IList<ProductSize> GetProductSizes()
        {
            return DataContext.ProductSizes.Where(s => s.IsDeleted == false).ToList();
        }

        public IList<ProductSize> GetProductSizes(string tag, string keyword)
        {
            var specification = new ProductSizeMatchingInTagSpecification(tag, keyword);
            return DataContext.ProductSizes.Where(specification.IsSatisfied()).ToList();
        }

        public void DeleteProductSize(string tag)
        {
            var result = DataContext.ProductSizes.SingleOrDefault(b => b.Name == tag);
            if (result != null) result.IsDeleted = true;
            DataContext.Entry(result).State = EntityState.Modified;
        }

        #endregion

        #region ProductAttribute
        public IList<ProductAttribute> GetProductAttributesByCategory(string category)
        {
            return DataContext.ProductAttributes
                .Where(a => a.Categories.Any(c => c.Name == category))
                .Include(a => a.AttributeOptions)
                .ToList();
        }

        public ProductAttribute GetProductAttribute(Guid attributeId)
        {
            return DataContext.ProductAttributes.SingleOrDefault(c => c.Id == attributeId);
        }

        public ProductAttributeOption GetProductAttributeOption(string optionName)
        {
            return DataContext.ProductAttributeOptions.SingleOrDefault(c => c.Name == optionName);
        }

        #endregion
    }

    #endregion

    #region ProductCommentRepository
    internal class ProductCommentRepository : RepositoryBase<ProductComment>, IProductCommentRepository
    {
        public ProductCommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    #endregion

    #region ProductRatingRepository
    internal class ProductRatingRepository : RepositoryBase<ProductRating>, IProductRatingRepository
    {
        public ProductRatingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    #endregion
}
