using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.StoreHandler;
using Seldino.Application.Query.DiscountService;
using Seldino.Application.Query.LocationService;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Areas.Management.Controllers
{
    [Authorize]
    public class StoreController : BaseController
    {
        private readonly IStoreQueryService _storeQueryService;
        private readonly ILocationQueryService _locationQueryService;
        private readonly IDiscountQueryService _discountQueryService;
        private readonly ICommandBus _commandBus;

        public StoreController(IStoreQueryService storeQueryService,
            ILocationQueryService locationQueryService,
            IDiscountQueryService discountQueryService,
            ICommandBus commandBus)
        {
            _storeQueryService = storeQueryService;
            _locationQueryService = locationQueryService;
            _discountQueryService = discountQueryService;
            _commandBus = commandBus;
        }

        public ActionResult List(int pageIndex)
        {
            var query = new StoresQueryRequest(pageIndex, PageSize, CurrentUser.Id);
            var response = _storeQueryService.GetStores(query);
            return View("List", response);
        }

        public ActionResult Create()
        {
            var command = new CreateStoreCommand();
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Create(CreateStoreCommand command)
        {
            if (!ModelState.IsValid) return View("Create");
            var pictures = PreparePicture(command.HttpPostedFileBases, StorePicturePath);
            command.Pictures = pictures;
            command.UserId = CurrentUser.Id;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(pictures, StorePicturePath);
            return JsonMessage(result);
        }

        public ActionResult Edit(Guid storeId)
        {
            var request = new StoreQueryRequest(storeId);
            var response = _storeQueryService.GetStoreById(request);

            if (response.Failed || response.Store == null)
            {
                return View("List");
            }

            var command = response.Store.ToCommand();
            FillStates(response.Store.Location.Country.Name);
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditStoreCommand command)
        {
            if (!ModelState.IsValid) return View("Edit");
            var pictures = PreparePicture(command.HttpPostedFileBases, StorePicturePath);
            command.Pictures = pictures;
            command.UserId = CurrentUser.Id;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(pictures, StorePicturePath);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Delete(DeleteStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Deactivate(DeactiveStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Activate(ActivateStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult Detail(Guid storeId)
        {
            var request = new StoreQueryRequest(storeId);
            var response = _storeQueryService.GetStoreById(request);
            return View("Detail", response);
        }


        [HttpPost]
        public JsonResult ApplyDiscount(ApplyStoreDiscountCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public JsonResult Discounts(Guid storeId)
        {
            var query = new DiscountQueryRequest(storeId);
            var response = _discountQueryService.GetAllDiscounts(query);
            return Json(response.Discounts);
        }

        public JsonResult GetStates(string country)
        {
            var response = _locationQueryService.GetStatesByCountry(new StatesQueryRequest { Country = country });
            return Json(response.States, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// States will be displayed based on choosen country
        /// </summary>
        /// <param name="country"></param>
        public void FillStates(string country)
        {
            var response = _locationQueryService.GetStatesByCountry(new StatesQueryRequest { Country = country });
            ViewBag.States = response.States;
        }
    }
}