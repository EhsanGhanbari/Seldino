using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class MembershipController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IMembershipQueryService _membershipQueryService;

        public MembershipController(ICommandBus commandBus, IMembershipQueryService membershipQueryService)
        {
            _commandBus = commandBus;
            _membershipQueryService = membershipQueryService;
        }

        public ActionResult Users(string keyword)
        {
            var query = new GetUsersQueryRequest(keyword);
            var users = _membershipQueryService.GetUsers(query);
            return View(users);
        }

        /// <summary>
        /// List of inactive users 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult Inactive(string keyword)
        {
            var query = new GetUsersQueryRequest(keyword);
            var users = _membershipQueryService.GetInactiveUsers(query);
            return View(users);
        }

        /// <summary>
        /// Activate a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Activate(ActivateUserCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        /// <summary>
        /// Deacticate a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Deactivate(DeactiveUserCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult DeleteUser(DeleteUserCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}