using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class MembershipController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IMembershipQueryService _membershipQueryService;

        public MembershipController(ICommandBus commandBus, IMembershipQueryService membershipQueryService)
        {
            _commandBus = commandBus;
            _membershipQueryService = membershipQueryService;
        }

        public ActionResult Users(int pageIndex, int pageSize)
        {
            var query = new GetUsersQueryRequest(pageIndex, pageSize);
            var response = _membershipQueryService.GetUsers(query);
            return View("Users", response.Users);
        }

        public ActionResult InactiveUsers(int pageIndex, int pageSize)
        {
            var query = new GetUsersQueryRequest(pageIndex, pageSize);
            var response = _membershipQueryService.GetInactiveUsers(query);
            return View("InactiveUsers", response.Users);
        }

        public ActionResult Detail(string email)
        {
            var query = new GetUserQueryRequest(email);
            var response = _membershipQueryService.GetUserDetailByEmail(query);
            return View("Detail", response);
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
            return Json(result.Message);
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
            return Json(result.Message);
        }

        [HttpPost]
        public JsonResult DeleteUser(DeleteUserCommand command)
        {
            var result = _commandBus.Send(command);
            return Json(result.Message);
        }

        public ActionResult CreateRole()
        {
            return View("CreateRole");
        }

        [HttpPost]
        public ActionResult CreateRole(RoleCommand command)
        {
            if (ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}