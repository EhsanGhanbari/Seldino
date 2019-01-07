using System;
using System.Web.Mvc;
using System.Web.Security;
using Seldino.Application.Command.BasketHandler;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Query.CookieService;
using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Authentication;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IMembershipQueryService _membershipQueryService;
        private readonly ICookieQueryService _cookieQueryService;

        public AccountController(
            ICommandBus commandBus,
            IMembershipQueryService membershipQueryService, 
            ICookieQueryService cookieQueryService)
        {
            _commandBus = commandBus;
            _membershipQueryService = membershipQueryService;
            _cookieQueryService = cookieQueryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadUserAccount()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult PartialRegister()
        {
            return PartialView("PartialRegister");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(RegisterUserCommand command)
        {
            if (!ModelState.IsValid) return PartialView("Register");
            var result = _commandBus.Send(command);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View("Register");
            }

            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [ChildActionOnly]
        public PartialViewResult PartialSignIn()
        {
            return PartialView("PartialSignIn");
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
            var user = _membershipQueryService.GetUserByEmail(new GetUserQueryRequest { Email = request.Email });

            if (response.Failed)
            {
                return JsonMessage(response);
            }

            var model = SetUserInformation(user.User);
            SerializeModel(model);
            TransferUnauthorizedBasket(model);

            if (request.RememberMe)
            {
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }

            if (!string.IsNullOrEmpty(request.ReturnUrl))
            {
                ViewBag.ReturnUrl = Server.UrlDecode(request.ReturnUrl);
            }

            return JsonMessage(response);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        public PartialViewResult ForgotPassword()
        {
            return PartialView("ForgotPassword");
        }

        [HttpPost]
        public ActionResult ForgotPassword(SendPasswordRecoveryLinkCommand command)
        {
            if (!ModelState.IsValid) return View("ForgotPassword");
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [Authorize]
        public ActionResult UpdateProfile()
        {
            var response = _membershipQueryService.GetUserProfileById(new GetUserProfileQueryRequest(CurrentUser.Id));

            if (!response.Failed)
            {
                if (response.Profile != null)
                {
                    var updateProfileCommand = response.Profile.ToCommand();
                    return View("UpdateProfile", updateProfileCommand);
                }
            }

            return View("UpdateProfile", new UpdateProfileCommand());
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateProfile(UpdateProfileCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateProfile", command);
            }

            var picture = PreparePicture(command.Picture.HttpPostedFileBase, MembershipPicturePath);
            command.UserId = CurrentUser.Id;
            command.Picture = picture;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(picture, MembershipPicturePath);
            return JsonMessage(result);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View("ChangePassword");
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordCommand command)
        {
            if (!ModelState.IsValid) return View("ChangePassword");
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        private static CustomPrincipalSerializeModel SetUserInformation(UserDto user)
        {
            return user.Profile == null
                ? new CustomPrincipalSerializeModel(user.UserId, user.Email, "")
                : new CustomPrincipalSerializeModel(user.UserId, user.Email, user.Profile.FirstName);
        }

        private void TransferUnauthorizedBasket(CustomPrincipalSerializeModel model)
        {
            var cookieId = _cookieQueryService.Retrieve(KadobinCookieId);

            if (!string.IsNullOrEmpty(cookieId))
            {
                var unauthorizedBasketCommand = new TransferUnauthorizedBasketCommand
                {
                    UserId = model.Id,
                    CookieId = Guid.Parse(cookieId)
                };

                _commandBus.Send(unauthorizedBasketCommand);
            }
        }
    }
}