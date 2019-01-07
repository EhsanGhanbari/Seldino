using Seldino.CrossCutting.Paging;
using System;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.ProductService
{

    public class ProductQureyRequest : QueryRequest
    {
        public ProductQureyRequest(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }

    public class ProductsQueryRequest : PagingQueryRequest
    {
        public ProductsQueryRequest()
        {
        }

        public ProductsQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public ProductsQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public ProductsQueryRequest(int pageIndex, int pageSize, int count)
            : base(pageIndex, pageSize, count)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
        }


        public Guid StoreId { get; set; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public string Tag { get; set; }

        public string Size { get; set; }

        public Guid ProductId { get; set; }
    }

    public class ProductColorQueryRequest : PagingQueryRequest
    {
        public ProductColorQueryRequest()
        {
        }

        public ProductColorQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public ProductColorQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public ProductColorQueryRequest(int pageIndex, int pageSize, int count)
            : base(pageIndex, pageSize, count)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
        }
    }

    public class ProductBrandQueryRequest : QueryRequest
    {
        public string Brand { get; set; }

        public ProductBrandQueryRequest(string brand)
        {
            Brand = brand;
        }
    }

    public class ProductCategoryQueryRequest : QueryRequest
    {
        public string Category { get; set; }

        public ProductCategoryQueryRequest(string category)
        {
            Category = category;
        }
    }

    public class ProductCategoriesQueryRequest : PagingQueryRequest
    {
        public ProductCategoriesQueryRequest()
        {
        }

        public ProductCategoriesQueryRequest(string keyword )
        {
            Keyword = keyword;
        }

        public ProductCategoriesQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public ProductCategoriesQueryRequest(int pageIndex, int pageSize, int count)
            : base(pageIndex, pageSize, count)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
        }

    }

    public class ProductSizeQueryRequest : QueryRequest
    {
        public ProductSizeQueryRequest(string category)
        {
            Category = category;
        }

        public string Category { get; set; }
    }

    public class ProductAttributesQueryRequest : QueryRequest
    {
        public string Category { get; set; }

        public ProductAttributesQueryRequest(string category)
        {
            Category = category;
        }
    }

    public class ProductTagQueryRequest
    {
        public  string Tag { get; set; }

        public ProductTagQueryRequest(string tag)
        {
            Tag = tag;
        }
    }
}
