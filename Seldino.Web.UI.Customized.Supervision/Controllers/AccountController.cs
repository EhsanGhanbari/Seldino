using System;
using System.Web.Mvc;
using System.Web.Security;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Authentication;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IMembershipQueryService _membershipQueryService;

        public AccountController(ICommandBus commandBus, IMembershipQueryService membershipQueryService)
        {
            _commandBus = commandBus;
            _membershipQueryService = membershipQueryService;
        }

        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult SignIn(AuthenticateQueryRequest request)
        {
            if (!ModelState.IsValid) return PartialView("SignIn");

            var response = _membershipQueryService.Authenticate(request);

            if (response.Failed)
            {
                return JsonMessage(response.Message);
            }

            var model = SetUserInformation(response.User);
            SerializeModel(model);

            if (request.RememberMe)
            {
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }

            if (!string.IsNullOrEmpty(request.ReturnUrl))
            {
                ViewBag.ReturnUrl = Server.UrlDecode(request.ReturnUrl);
            }

            return RedirectToAction("Index","Dashboard");
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Dashboard");
        }

        [Authorize]
        public PartialViewResult ForgotPassword()
        {
            return PartialView("ForgotPassword");
        }

        [Authorize]
        [HttpPost]
        public ActionResult ForgotPassword(SendPasswordRecoveryLinkCommand command)
        {
            if (!ModelState.IsValid) return View("ForgotPassword");
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        private static CustomPrincipalSerializeModel SetUserInformation(UserDto user)
        {
            return user.Profile == null
                ? new CustomPrincipalSerializeModel(user.UserId, user.Email, "")
                : new CustomPrincipalSerializeModel(user.UserId, user.Email, user.Profile.FirstName);
        }
    }
}