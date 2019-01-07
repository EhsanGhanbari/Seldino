using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.ProductHandler;
using Seldino.Application.Query.ProductService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IProductQueryService _productQueryService;

        public ProductController(ICommandBus commandBus, IProductQueryService productQueryService)
        {
            _commandBus = commandBus;
            _productQueryService = productQueryService;
        }

        #region Product

        /// <summary>
        /// Returns products by a keyword 
        /// Returns products of a user
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string keyword)
        {
            var query = new ProductsQueryRequest() { Keyword = keyword };
            var products = _productQueryService.GetProducts(query);
            return View(products);
        }

        public ActionResult Detail(Guid productId)
        {
            var product = _productQueryService.GetProductDetailById(new ProductQureyRequest(productId));
            return View(product);
        }

        [HttpPost]
        public JsonResult DeleteProduct(DeleteProductCommand command)
        {
            if (ModelState.IsValid) return Json(ModelState.Values);
            var result = _commandBus.Send(command);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Category

        /// <summary>
        /// Returns all categories of the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories(string keyword)
        {
            var productCategory = _productQueryService.GetProductCategories(new ProductCategoriesQueryRequest(keyword));
            return View(productCategory);
        }

        /// <summary>
        /// Returns products by category
        /// </summary>
        /// <returns></returns>
        public ActionResult Category(string category)
        {
            var query = new ProductsQueryRequest() { Category = category };
            var products = _productQueryService.GetProductsByCategory(query);
            return View(products);
        }

        [HttpPost]
        public JsonResult DeleteCategory(DeleteProductCategoryCommand command)
        {
            if (ModelState.IsValid) return Json(ModelState.Values);
            var result = _commandBus.Send(command);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Brand

        /// <summary>
        /// Displays the list of all brands created by users
        /// </summary>
        /// <returns></returns>
        public ActionResult Brands(string keyword)
        {
            var query = new ProductsQueryRequest();
            var productBrands = _productQueryService.GetProductBrands(query);
            return View("Brands", productBrands);
        }

        /// <summary>
        /// Returns all products by brand
        /// </summary>
        /// <returns></returns>
        public ActionResult Brand(string category, string brand)
        {
            var query = new ProductsQueryRequest();
            var products = _productQueryService.GetProductsByBrand(query);
            return View(products);
        }

        [HttpPost]
        public JsonResult DeleteBrand(DeleteProductBrandCommand command)
        {
            if (ModelState.IsValid) return Json(ModelState.Values);
            var result = _commandBus.Send(command);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Tags

        /// <summary>
        /// Returns all tags of the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Tags(string keyword)
        {
            var query = new ProductsQueryRequest();
            var productTag = _productQueryService.GetPrductTags(query);
            return View(productTag);
        }

        /// <summary>
        /// Returns all tag of the 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ActionResult Tag(string category, string tag)
        {
            var query = new ProductsQueryRequest();
            var products = _productQueryService.GetProductsByTag(query);
            return View(products);
        }

        public JsonResult DeleteTag(DeleteProductTagCommand command)
        {
            if (ModelState.IsValid) return Json(ModelState.Values);
            var result = _commandBus.Send(command);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Color

        public ActionResult Colors(string keyword)
        {
            var color = _productQueryService.GetProductColors(new ProductColorQueryRequest(1, 20) { Keyword = keyword });
            return View(color);
        }

        [HttpPost]
        public JsonResult DeleteColor(DeleteProductColorCommand command)
        {
            var result = _commandBus.Send(command);
            return Json(result.Message, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Size

        public ActionResult Sizes(string keyword)
        {
            var query = new ProductSizeQueryRequest(keyword);
            var sizes = _productQueryService.GetProductSizes(query);
            return View(sizes);
        }

        [HttpPost]
        public JsonResult DeleteSize(DeleteProductSizeCommand command)
        {
            var result = _commandBus.Send(command);
            return Json(result.Success, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Comment

        public JsonResult RemoveComment(DeleteProductCommentCommand command)
        {
            var result = _commandBus.Send(command);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}