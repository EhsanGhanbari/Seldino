using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.GiftDeskHandler;
using Seldino.Application.Query.GiftDeskService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class GiftDeskController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IGiftDeskQueryService _giftDeskQueryService;

        public GiftDeskController(ICommandBus commandBus, IGiftDeskQueryService giftDeskQueryService)
        {
            _commandBus = commandBus;
            _giftDeskQueryService = giftDeskQueryService;
        }

        public ActionResult Index()
        {
            var response = _giftDeskQueryService.GetGiftDesks(new GiftDesksQueryRequest(CurrentUser.Id));
            return View("Index", response);
        }

        /// <summary>
        /// Adding item to gift desk
        /// </summary>
        /// <returns></returns>
        public ActionResult AddItem(AddToGiftDeskCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult RemoveItem(RemoveFromGiftDeskCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult VerifyRequest(VerifyRequestOfGiftDeskCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult RemoveFriend(RemoveFriendFromGiftDeskAccessCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}