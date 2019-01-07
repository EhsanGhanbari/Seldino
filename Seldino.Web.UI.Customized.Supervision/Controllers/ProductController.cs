using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.ProductHandler;
using Seldino.Application.Query.ProductService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        #region Field
        private readonly ICommandBus _commandBus;
        private readonly IProductQueryService _productQueryService;
        #endregion

        #region Constrcutor

        public ProductController(ICommandBus commandBus, IProductQueryService productQueryService)
        {
            _commandBus = commandBus;
            _productQueryService = productQueryService;
        }

        #endregion

        #region Product

        /// <summary>
        /// Returns products by a keyword 
        /// Returns products of a user
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize);
            var response = _productQueryService.GetProducts(query);
            return View("List", response);
        }

        public ActionResult Detail(Guid productId)
        {
            var query = _productQueryService.GetProductDetailById(new ProductQureyRequest(productId));
            return View("Detail", query);
        }

        [HttpPost]
        public JsonResult DeleteProduct(DeleteProductCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Category

        /// <summary>
        /// Returns all categories of the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories(int pageIndex)
        {
            var query = new ProductCategoriesQueryRequest(pageIndex, PageSize);
            var productCategory = _productQueryService.GetProductCategories(query);
            return View("Categories", productCategory);
        }

        /// <summary>
        /// Returns products by category
        /// </summary>
        /// <returns></returns>
        public ActionResult Category(string category, int pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize) { Category = category };
            var products = _productQueryService.GetProductsByCategory(query);
            return View("Category", products);
        }

        [HttpPost]
        public JsonResult DeleteCategory(DeleteProductCategoryCommand command)
        {
            if (ModelState.IsValid) return Json(ModelState.Values);
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Brand

        /// <summary>
        /// Displays the list of all brands created by users
        /// </summary>
        /// <returns></returns>
        public ActionResult Brands(int pageIndex, string keyword)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize) { Keyword = keyword };
            var productBrands = _productQueryService.GetProductBrands(query);
            return View("Brands", productBrands);
        }

        /// <summary>
        /// Returns all products by brand
        /// </summary>
        /// <returns></returns>
        public ActionResult Brand(string category, string brand, int pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize) { Category = category, Brand = brand };
            var products = _productQueryService.GetProductsByBrand(query);
            return View("Brand", products);
        }

        [HttpPost]
        public JsonResult DeleteBrand(DeleteProductBrandCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Tags

        /// <summary>
        /// Returns all tags of the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Tags(int pageIndex, string keyword)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize) { Keyword = keyword };
            var productTag = _productQueryService.GetPrductTags(query);
            return View("Tags", productTag);
        }

        /// <summary>
        /// Returns all tags of the system
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="category"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ActionResult Tag(string category, string tag, int pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize) { Category = category, Tag = tag };
            var products = _productQueryService.GetProductsByTag(query);
            return View(products);
        }

        [HttpPost]
        public JsonResult DeleteTag(DeleteProductTagCommand command)
        {
            if (ModelState.IsValid) return Json(ModelState.Values);
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Color

        public ActionResult Colors(string keyword)
        {
            var query = new ProductColorQueryRequest(keyword);
            var color = _productQueryService.GetProductColors(query);
            return View("Colors", color);
        }

        [HttpPost]
        public JsonResult DeleteColor(DeleteProductColorCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Size

        public ActionResult Sizes(string keyword)
        {
            var query = new ProductSizeQueryRequest(keyword);
            var sizes = _productQueryService.GetProductSizes(query);
            return View("Sizes", sizes);
        }

        [HttpPost]
        public JsonResult DeleteSize(DeleteProductSizeCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Comment

        [HttpPost]
        public JsonResult DeleteComment(DeleteProductCommentCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion
    }
}