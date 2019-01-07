using System;
using System.Web.Mvc;
using Seldino.Application.Command.BasketHandler;
using Seldino.Application.Command.BasketHandler.Unauthorized;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.BasketService;
using Seldino.Application.Query.BasketService.Unauthorized;
using Seldino.Application.Query.CookieService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class BasketController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IBasketQueryService _basketQueryService;
        private readonly IUnauthorizedBasketQueryService _unauthorizedBasketQueryService;
        private readonly ICookieQueryService _cookieQueryService;

        public BasketController(
            ICommandBus commandBus,
            IBasketQueryService basketQueryService,
            IUnauthorizedBasketQueryService unauthorizedBasketQueryService,
            ICookieQueryService cookieQueryService)
        {
            _commandBus = commandBus;
            _basketQueryService = basketQueryService;
            _cookieQueryService = cookieQueryService;
            _unauthorizedBasketQueryService = unauthorizedBasketQueryService;
        }

        public JsonResult UpdateBasket()
        {
            var query = new BasketQueryRequest(1, PageSize) { UserId = CurrentUser.Id };
            var response = _basketQueryService.GetBasketItems(query);
            return Json(response);
        }

        public ActionResult Card()
        {
            if (CurrentUser != null && CurrentUser.Id != Guid.Empty)
            {
                var query = new BasketQueryRequest(1, PageSize) { UserId = CurrentUser.Id };
                var response = _basketQueryService.GetBasketItems(query);
                return View("Card", response);
            }

            var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);
            var unauthorizedquery = new BasketQueryRequest(1, PageSize) { CookieId = Guid.Parse(cookieId) };
            var unauthorizedResponse = _unauthorizedBasketQueryService.GetBasketItems(unauthorizedquery);
            return View("Card", unauthorizedResponse);
        }

        /// <summary>
        /// List of items in basket for current user in notification bar
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ShowBasket(int pageIndex, int pageSize)
        {
            if (CurrentUser != null && CurrentUser.Id != Guid.Empty)
            {
                var query = new BasketQueryRequest(1, PageSize) { UserId = CurrentUser.Id };
                var response = _basketQueryService.GetBasketItems(query);
                return PartialView("ShowBasket", response);
            }

            var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);

            if (string.IsNullOrEmpty(cookieId))
            {
                return PartialView("ShowBasket", null);
            }

            var unauthorizedquery = new BasketQueryRequest(1, PageSize) { CookieId = Guid.Parse(cookieId) };
            var unauthorizedResponse = _unauthorizedBasketQueryService.GetBasketItems(unauthorizedquery);
            return PartialView("ShowBasket", unauthorizedResponse);
        }

        [HttpGet]
        public ActionResult GetBasket()
        {
            if (CurrentUser != null && CurrentUser.Id != Guid.Empty)
            {
                var query = new BasketQueryRequest(1, PageSize) { UserId = CurrentUser.Id };
                var response = _basketQueryService.GetBasketItems(query);
                return PartialView("ShowBasket", response);
            }

            var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);

            if (string.IsNullOrEmpty(cookieId))
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var unauthorizedquery = new BasketQueryRequest(1, PageSize) { CookieId = Guid.Parse(cookieId) };
            var unauthorizedResponse = _unauthorizedBasketQueryService.GetBasketItems(unauthorizedquery);

            return Json(unauthorizedResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddItem(AddItemToBasketCommand command)
        {
            if (CurrentUser != null && CurrentUser.Id != Guid.Empty)
            {
                command.UserId = CurrentUser.Id;
                var result = _commandBus.Send(command);
                return JsonMessage(result);
            }

            var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);
            var cookieIdValue = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(cookieId))
            {
                _cookieQueryService.Save(KadobinCookieId, cookieIdValue, DateTime.Now.AddDays(30));
            }
            else
            {
                cookieIdValue = cookieId;
            }

            var unauthorizedBasketCommand = new AddItemToUnauthorizedBasketCommand()
            {
                Quantity = command.Quantity,
                CookieId = Guid.Parse(cookieIdValue),
                ProductIds = command.ProductIds
            };

            var unauthorizedResult = _commandBus.Send(unauthorizedBasketCommand);
            return JsonMessage(unauthorizedResult);
        }

        [HttpPost]
        public ActionResult RemoveItem(RemoveItemFromBasketCommand command)
        {
            if (CurrentUser != null && CurrentUser.Id != Guid.Empty)
            {
                command.UserId = CurrentUser.Id;
                var result = _commandBus.Send(command);
                return JsonMessage(result);
            }

            var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);
            var cookieIdValue = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(cookieId))
            {
                _cookieQueryService.Save(KadobinCookieId, cookieIdValue, DateTime.Now.AddDays(30));
            }
            else
            {
                cookieIdValue = cookieId;
            }

            var unauthorizedBasketCommand = new RemoveItemFromUnauthorizedBasketCommand
            {
                CookieId = Guid.Parse(cookieIdValue),
                ProductIds = command.ProductIds
            };

            var unauthorizedResult = _commandBus.Send(unauthorizedBasketCommand);
            return JsonMessage(unauthorizedResult);
        }

        /// <summary>
        /// Finalize the basket item to make order
        /// there is already a Finalize method in  Controller base!
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(UpdateBasketQuantityCommand command)
        {
            if (CurrentUser != null)
            {
                command.UserId = CurrentUser.Id;
                var result = _commandBus.Send(command);
                return JsonMessage(result);
            }
            else
            {
                var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);
                var cookieIdValue = Guid.NewGuid().ToString();

                if (string.IsNullOrEmpty(cookieId))
                {
                    _cookieQueryService.Save(KadobinCookieId, cookieIdValue, DateTime.Now.AddDays(30));
                }
                else
                {
                    cookieIdValue = cookieId;
                }

                var unAuthorizedCommand = new UpdateUnAuthorizedBasketQuantityCommand
                {
                    Quantity = command.Quantity,
                    ProductId = command.ProductId,
                    CookieId = Guid.Parse(cookieIdValue)
                };

                var result = _commandBus.Send(unAuthorizedCommand);
                return JsonMessage(result);
            }
        }
    }
}