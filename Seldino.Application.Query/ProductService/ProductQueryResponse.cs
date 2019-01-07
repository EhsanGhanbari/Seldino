using System.Collections.Generic;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.ProductService
{
    public class ProductQueryResponse : QueryResponse
    {
        public ProductDto Product { get; set; }
    }

    public class ProductsQueryResponse : QueryResponse
    {
        public PagingQueryResponse<ProductDto> Products { get; set; }
    }

    public class ProductColorQueryResponse : QueryResponse
    {
        public IList<ProductColorDto> ProductColors { get; set; }
    }

    public class ProductBrandQueryResponse : QueryResponse
    {
        public ProductBrandDto Brand { get; set; }
    }

    public class ProductBrandsQueryResponse : QueryResponse
    {
        public IList<ProductBrandDto> Brands { get; set; }
    }

    public class ProductCategoryQueryResponse : QueryResponse
    {
        public ProductCategoryDto Category { get; set; }
    }

    public class ProductCategoriesQueryResponse : QueryResponse
    {
        public IList<ProductCategoryDto> Categories { get; set; }
    }

    public class ProductSizeQueryResponse : QueryResponse
    {
        public IList<ProductSizeDto> Sizes { get; set; }
    }

    public class ProductAttributesQueryResponse : QueryResponse
    {
        public IList<ProductAttributeDto> Attributes { get; set; }
    }

    public class ProductTagQueryResponse : QueryResponse
    {
        public ProductTagDto Tag { get; set; }
    }

    public class ProductTagsQueryResponse : QueryResponse
    {
        public IList<ProductTagDto> Tags { get; set; }
    }
}
