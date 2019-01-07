using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.DiscountHandler;
using Seldino.Application.Query.DiscountService;
using Seldino.Application.Query.ProductService;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Areas.Management.Controllers
{
    [Authorize]
    public class DiscountController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IDiscountQueryService _discountQueryService;
        private readonly IProductQueryService _productQueryService;
        private readonly IStoreQueryService _storeQueryService;

        public DiscountController(ICommandBus commandBus, IDiscountQueryService discountQueryService, IProductQueryService productQueryService, IStoreQueryService storeQueryService)
        {
            _commandBus = commandBus;
            _discountQueryService = discountQueryService;
            _productQueryService = productQueryService;
            _storeQueryService = storeQueryService;
        }


        /// <summary>
        /// List of all dicount template of the current user
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult List(int pageIndex)
        {
            var query = new DiscountQueryRequest(pageIndex, PageSize);
            var response = _discountQueryService.GetAllDiscounts(query);
            return View("List", response);
        }

        /// <summary>
        /// list of all stopped discounts
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Inactive(int pageIndex)
        {
            var query = new DiscountQueryRequest(pageIndex, PageSize);
            var discounts = _discountQueryService.GetAllInactiveDiscounts(query);
            return View("Inactive", discounts);
        }

        /// <summary>
        /// All actrive discount template
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Active(int pageIndex)
        {
            var query = new DiscountQueryRequest(pageIndex, PageSize);
            var discounts = _discountQueryService.GetAllActiveDiscounts(query);
            return View("Active", discounts);
        }

        public ActionResult Create()
        {
            var command = new CreateDiscountCommand();
            FillControlls(command);
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Create(CreateDiscountCommand command)
        {
            if (!ModelState.IsValid)
            {
                FillControlls(command);
                return View("Create");
            }

            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult Edit(Guid discountId)
        {
            var response = _discountQueryService.GetDiscountById(new DiscountQueryRequest(discountId));

            if (response.Failed || response.Discount == null)
            {
                //ToDo alert
                return View("List");
            }

            var command = response.Discount.ToCommand();
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditDiscountCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", command);
            }

            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Delete(DeleteDiscountCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        private void FillControlls(IDiscountCommand command)
        {
            FillCategories();
            FillStores();
            FillBrands();
            FillTags();
        }

        private void FillCategories()
        {
            var query = new ProductCategoriesQueryRequest();
            var response = _productQueryService.GetProductCategories(query);
            ViewBag.ProductCategories = response.Categories;
        }

        private void FillStores()
        {
            var query = new StoresQueryRequest(1, 20, CurrentUser.Id);
            var response = _storeQueryService.GetStores(query);
            ViewBag.Stores = response.Stores;
        }

        private void FillBrands()
        {
            var query = new ProductsQueryRequest();
            var response = _productQueryService.GetProductBrands(query);
            ViewBag.ProductBrands = response.Brands;
        }

        private void FillTags()
        {
            var query = new ProductsQueryRequest();
            var response = _productQueryService.GetPrductTags(query);
            ViewBag.ProductTags = response.Tags;
        }
    }
}