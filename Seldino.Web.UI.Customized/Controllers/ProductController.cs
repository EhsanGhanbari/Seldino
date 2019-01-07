using System;
using System.Web.Mvc;
using System.Web.UI;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.ProductHandler;
using Seldino.Application.Query.ProductService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class ProductController : BaseController
    {
        #region Fields
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
        /// Returns the detail of a product by Id
        /// CreationDate, Owner store, brand, Category, Tag
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Detail(Guid productId)
        {
            var response = _productQueryService.GetProductDetailById(new ProductQureyRequest(productId));
            _commandBus.Send(new IncreaseProductVisitCountCommand { ProductId = productId });
            return View("Detail", response.Product);
        }

        /// <summary>
        /// Latest created products
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult Latest()
        {
            var query = new ProductsQueryRequest(1, 5);
            var products = _productQueryService.GetLatestProducts(query);
            return PartialView("Latest", products.Products);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult SpecialState()
        {
            var query = new ProductsQueryRequest(1, 6);
            var products = _productQueryService.GetSpecialProducts(query);
            return PartialView("SpecialState", products.Products);
        }

        /// <summary>
        /// return Best selling product requested by user
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult BestSelling()
        {
            var query = new ProductsQueryRequest(1, 6);
            var products = _productQueryService.GetBestSellingProducts(query);
            return PartialView("BestSelling", products.Products);
        }

        /// <summary>
        /// List of best selling products
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult BestSellings(int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize);
            var response = _productQueryService.GetBestSellingProducts(query);
            return View("BestSellings", response.Products);
        }

        /// <summary>
        /// Most visited products 
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult Popular()
        {
            var query = new ProductsQueryRequest(1, 6);
            var products = _productQueryService.GetPopularProducts(query);
            return PartialView("Popular", products);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Populars(int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize);
            var products = _productQueryService.GetPopularProducts(query);
            return View("Populars", products);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult MostVisited()
        {
            var query = new ProductsQueryRequest(1, 6);
            var products = _productQueryService.GetMostvisitedProducts(query);
            return PartialView("MostVisited", products);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult MostVisiteds(int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize);
            var products = _productQueryService.GetMostvisitedProducts(query);
            return View("MostVisiteds", products);
        }

        /// <summary>
        /// returns the similait products of a products
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult Similar(Guid productId)
        {
            var query = new ProductsQueryRequest(1, PageSize) { ProductId = productId };
            var products = _productQueryService.GetSimiliarProducts(query);
            return PartialView("Similar", products.Products);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult Discounted()
        {
            var query = new ProductsQueryRequest(1, 6);
            var products = _productQueryService.GetDiscountedProducts(query);
            return PartialView("Discounted", products.Products);
        }

        /// <summary>
        /// Lists all discounted products in the system by data
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Discounteds(int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize);
            var products = _productQueryService.GetDiscountedProducts(query);
            return View("Discounteds", products.Products);
        }

        /// <summary>
        /// Returns all categories of the system
        /// </summary>
        /// <returns></returns>
        /// 
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult Categories()
        {
            var query = new ProductCategoriesQueryRequest(1, PageSize);
            var response = _productQueryService.GetProductCategories(query);
            return PartialView("Categories", response);
        }

        /// <summary>
        /// Lists all products of the system by a spesific category 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Category(string category, int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize) { Category = category };
            var products = _productQueryService.GetProductsByCategory(query);
            return View("Category", products);
        }

        /// <summary>
        /// Lists all products by a spesific tag
        /// </summary>
        /// <param name="category"></param>
        /// <param name="tag"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Tag(string category, string tag, int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize) { Category = category, Tag = tag };
            var products = _productQueryService.GetProductsByTag(query);
            return View("Tag", products);
        }

        /// <summary>
        /// Returns all tags of the system
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult Tags(int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize);
            var productTag = _productQueryService.GetPrductTags(query);
            return PartialView("Tags", productTag);
        }

        /// <summary>
        /// Displays the list of all brands created by users
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Brands(int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize);
            var productBrands = _productQueryService.GetProductBrands(query);
            return Json(productBrands.Brands);
        }

        /// <summary>
        /// Lists All products by a spesific brand by brand name
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Brand(string category, string brand, int? pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex ?? 1, PageSize) { Category = category, Brand = brand };
            var response = _productQueryService.GetProductsByBrand(query);
            return View("Brand", response);
        }

        #endregion

        #region Comment

        /// <summary>
        /// Only logged in user can create comment
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public PartialViewResult CreateComment(Guid productId)
        {
            ViewBag.ProductId = productId;
            return PartialView("CreateComment");
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateComment(CreateProductCommentCommand command)
        {
            if (!ModelState.IsValid) { return PartialView("CreateComment"); }
            command.UserId = CurrentUser.Id;
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [Authorize]
        public PartialViewResult ReplyToComment(Guid commentId)
        {
            ViewBag.CommentId = commentId;
            return PartialView("ReplyToComment");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ReplyToComment(ReplyToProductCommentCommand command)
        {
            if (!ModelState.IsValid) { return PartialView("ReplyToComment"); }
            command.UserId = CurrentUser.Id;
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Search

        public PartialViewResult SearchForm()
        {
            //var query = new ProductCategoriesQueryRequest();
            //var productCategories = _productQueryService.GetProductCategories(query);
            ////ViewData["ProductCategories"] = productCategories;

            //ViewData["ProductCategories"] = productCategories.Categories;
            return PartialView();
        }

        /// <summary>
        /// keyword: search term
        /// Value: Category 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="category"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search(string category, string keyword, int pageIndex, int pageSize)
        {
            var query = new ProductsQueryRequest(pageIndex, pageSize) { Category = category, Keyword = keyword };
            var result = _productQueryService.SearchInProducts(query);
            return View(result);
        }

        #endregion

        #region Rating

        public PartialViewResult RateProduct()
        {
            return PartialView("RateProduct");
        }

        /// <summary>
        /// only logged in users can rate a product 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RateProduct(RateProductCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion
    }
}