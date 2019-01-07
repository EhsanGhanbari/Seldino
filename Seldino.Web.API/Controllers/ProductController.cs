using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Seldino.Application.Query.ProductService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.API.Controllers
{
    /// <summary>
    /// http://jamessdixon.wordpress.com/2013/10/01/handling-images-in-webapi/
    /// </summary>
    public class ProductController : BaseApiController
    {
        private readonly IProductQueryService _productQueryService;

        public ProductController(IProductQueryService productQueryService)
        {
            _productQueryService = productQueryService;
        }

        [HttpGet]
        public HttpResponseMessage GetProductDetail(Guid productId)
        {
            var product = _productQueryService.GetProductDetailById(new ProductQureyRequest(productId));
            return Request.CreateResponse(product == null ? HttpStatusCode.NoContent : HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage GetPopularProducts()
        {
            var query = new ProductsQueryRequest();
            var products = _productQueryService.GetPopularProducts(query);
            return Request.CreateResponse(products == null ? HttpStatusCode.NoContent : HttpStatusCode.OK);
        }

        public HttpResponseMessage GetDiscountedProducts()
        {
            var query = new ProductsQueryRequest();
            var products = _productQueryService.GetDiscountedProducts(query);
            return Request.CreateResponse(products == null ? HttpStatusCode.NoContent : HttpStatusCode.OK);
        }

        public HttpResponseMessage GetProductsByBrand(string category, string brand)
        {
            var query = new ProductsQueryRequest();
            var productBrand = _productQueryService.GetProductsByBrand(query);
            return Request.CreateResponse(productBrand == null ? HttpStatusCode.NoContent : HttpStatusCode.OK);
        }

        /// <summary>
        /// Lists all products of the system by a spesific category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public HttpResponseMessage GetProductsByCategory(string category)
        {
            var query = new ProductsQueryRequest();
            var productCategory = _productQueryService.GetProductsByCategory(query);
            return Request.CreateResponse(productCategory == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }

        /// <summary>
        /// Lists all products by a spesific tag
        /// </summary>
        /// <param name="category"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public HttpResponseMessage GetProductsByTag(string category, string tag)
        {
            var query = new ProductsQueryRequest();
            var productTag = _productQueryService.GetProductsByTag(query);
            return Request.CreateResponse(productTag == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }

        /// <summary>
        /// Displays the list of all brands created by users
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetProductBrands()
        {
            var query = new ProductsQueryRequest();
            var productBrands = _productQueryService.GetProductBrands(query);
            return Request.CreateResponse(productBrands == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns all categories of the system
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetProductCategories()
        {
            var query = new ProductCategoriesQueryRequest();
            var productCategory = _productQueryService.GetProductCategories(query);
            return Request.CreateResponse(productCategory == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns all tags of the system
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetProductTags()
        {
            var query = new ProductsQueryRequest();
            var productTag = _productQueryService.GetPrductTags(query);
            return Request.CreateResponse(productTag == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }
    }
}
