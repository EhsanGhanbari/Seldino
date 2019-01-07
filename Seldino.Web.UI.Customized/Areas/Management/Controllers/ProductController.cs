using System;
using System.Linq;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.ProductHandler;
using Seldino.Application.Query.DiscountService;
using Seldino.Application.Query.ProductService;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Areas.Management.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        #region Fields

        private readonly ICommandBus _commandBus;
        private readonly IProductQueryService _productQueryService;
        private readonly IStoreQueryService _storeQueryService;
        private readonly IDiscountQueryService _discountQueryService;

        #endregion

        #region Constructor
        public ProductController(
            ICommandBus commandBus,
            IProductQueryService productQueryService,
            IStoreQueryService storeQueryService,
            IDiscountQueryService discountQueryService)
        {
            _commandBus = commandBus;
            _productQueryService = productQueryService;
            _storeQueryService = storeQueryService;
            _discountQueryService = discountQueryService;
        }

        #endregion

        /// <summary>
        /// Returns all products of the current user
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string keyword, int pageIndex)
        {
            var query = new ProductsQueryRequest(pageIndex, PageSize) { Keyword = keyword, UserId = CurrentUser.Id };
            var products = _productQueryService.GetProducts(query);
            return View("List", products);
        }

        /// <summary>
        /// Returns the detail of a product by Id
        /// CreationDate, Owner store, brand, Category, Tag
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid productId)
        {
            var product = _productQueryService.GetProductDetailById(new ProductQureyRequest(productId));
            return View("Detail", product.Product);
        }

        /// <summary>
        /// Create Product
        /// Brands,Category,Tag,Manufacturer,Picture will be persisted for the product
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var command = new CreateProductCommand();
            FillControlls(command);
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Create(CreateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                FillControlls(command);
                return View("Create", command);
            }

            var pictures = PreparePicture(command.HttpPostedFileBases, ProductPicturePath);
            command.ProductPictures = pictures;
            command.UserIdentity = CurrentUserIdentity;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(pictures, ProductPicturePath);
            return JsonMessage(result);
        }

        public ActionResult Edit(Guid productId)
        {
            var query = _productQueryService.GetProductDetailById(new ProductQureyRequest(productId));
            var command = query.Product.ToCommand();
            FillControlls(command);
            SetSelectedValues(command, query.Product);
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                FillCategories();
                return View("Edit", command);
            }

            var pictures = PreparePicture(command.HttpPostedFileBases, ProductPicturePath);
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(pictures, ProductPicturePath);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Delete(DeleteProductCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }


        /// <summary>
        /// Loads Tags by category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public JsonResult Tags(string category, string keyword)
        {
            var query = new ProductsQueryRequest { Category = category, Keyword = keyword };
            var response = _productQueryService.GetPrductTags(query);
            return Json(response.Tags, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Loads brands by category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public JsonResult Brands(string category, string keyword)
        {
            var query = new ProductsQueryRequest { Category = category, Keyword = keyword };
            var response = _productQueryService.GetProductBrands(query);
            return Json(response.Brands, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Loads attribute by selected category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public JsonResult Attribute(string category)
        {
            var attributes = _productQueryService.GetProductAttributesByCategory(new ProductAttributesQueryRequest(category));
            return Json(attributes, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ApplyDiscountForm(Guid[] productIds, string storeId)
        {
            ViewBag.ProductIds = productIds;
            ViewBag.StoreId = storeId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult ApplyDiscount(ApplyProductDiscountCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public PartialViewResult Discounts(Guid storeId)
        {
            var query = new DiscountQueryRequest(storeId);
            var response = _discountQueryService.GetAllDiscounts(query);
            return PartialView(response);
        }

        private void FillControlls(IProductCommand command)
        {
            FillCategories();
            FillStores(command);
        }

        private void FillCategories()
        {
            var query = new ProductCategoriesQueryRequest();
            var response = _productQueryService.GetProductCategories(query);
            ViewBag.ProductCategories = response.Categories;
        }

        private void FillStores(IProductCommand command)
        {
            var query = new StoresQueryRequest(1, 20, CurrentUser.Id);
            var response = _storeQueryService.GetStores(query);
            ViewBag.Stores = response.Stores;
        }

        private static void SetSelectedValues(IProductCommand command, ProductDto product)
        {
            SetSelectdCategory(command, product);
            SetSelectdBrand(command, product);
            SetSelectTag(command, product);
            SetSelectedAttribute(command, product);
        }

        private static void SetSelectdCategory(IProductCommand command, ProductDto product)
        {
            if (command.ProductCategory == null) return;

            if (product.ProductCategory.Name == command.ProductCategory.Name)
            {
                command.ProductCategory.IsSelected = true;
            }
        }

        private static void SetSelectedAttribute(IProductCommand command, ProductDto product)
        {
            if (command.ProductAttributes == null) return;

            foreach (var attribute in product.ProductCategory.ProductAttributes.Where(c => c.Name != null))
            {
                foreach (var option in attribute.AttributeOptions)
                {
                    command.ProductAttributes.Select(c => c.AttributeOptionCommands.First(o => o.Name == option.Name).IsSelected == true);
                }
            }
        }

        private static void SetSelectdBrand(IProductCommand command, ProductDto product)
        {
            if (command.ProductBrand == null) return;

            if (product.ProductBrand.Name == command.ProductBrand.Name)
            {
                command.ProductBrand.IsSelected = true;
            }
        }

        private static void SetSelectTag(IProductCommand command, ProductDto product)
        {
            if (command.ProductTags == null) return;

            foreach (var tag in product.ProductTags.Where(c => c.Name != null))
            {
                command.ProductTags.First(c => c.Name == tag.Name).IsSelected = true;
            }
        }
    }
}