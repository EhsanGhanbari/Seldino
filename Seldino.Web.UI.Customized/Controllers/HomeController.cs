using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Query.DocumentService;
using Seldino.CrossCutting.Utilities;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Helpers;
using Seldino.CrossCutting.Web.ViewMessages;

namespace Seldino.Web.UI.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor

        private readonly ICommandBus _commandBus;
        private readonly IDocumentQueryService _documentQueryService;

        public HomeController(ICommandBus commandBus, IDocumentQueryService documentQueryService)
        {
            _commandBus = commandBus;
            _documentQueryService = documentQueryService;
        }

        #endregion

        #region Default

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Contact

        public ActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public ActionResult Contact(CreateMessageCommand command)
        {
            if (!ModelState.IsValid) return View("Contact");

            if (CaptchaIsValid())
            {
                var result = _commandBus.Send(command);
                return JsonMessage(result);
            }

            ViewBag.ErrMessage = NotificationViewMessage.InvalidaCaptcha;
            return View("Contact");
        }

        #endregion

        #region Document

        public ActionResult About()
        {
            var response = _documentQueryService.GetDefaultDocument(new DocumentQueryRequest());
            return View("About", response.Document);
        }

        [OutputCache(Duration = 60000)]
        public PartialViewResult SocialMedia()
        {
            var response = _documentQueryService.GetDefaultDocument(new DocumentQueryRequest());
            return PartialView("SocialMedia", response.Document);
        }

        [OutputCache(Duration = 60000)]
        public ActionResult Rule()
        {
            var response = _documentQueryService.GetDefaultDocument(new DocumentQueryRequest());
            return View("Rule", response.Document);
        }

        [OutputCache(Duration = 60000)]
        public ActionResult Guide()
        {
            var response = _documentQueryService.GetDefaultDocument(new DocumentQueryRequest());
            return View("Guide", response.Document);
        }

        [OutputCache(Duration = 60000)]
        public ActionResult Information()
        {
            var response = _documentQueryService.GetDefaultDocument(new DocumentQueryRequest());
            return View("Information", response.Document);
        }



        #endregion

        #region Culture
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

        #endregion

        private bool CaptchaIsValid()
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LegBgoTAAAAAMK26-1cCMRVblKaPUWPYSPiWA3q";

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0) return false;

                //var error = captchaResponse.ErrorCodes[0].ToLower();
                //switch (error)
                //{
                //    case ("missing-input-secret"):
                //        ViewBag.Message = "The secret parameter is missing.";
                //        break;
                //    case ("invalid-input-secret"):
                //        ViewBag.Message = "The secret parameter is invalid or malformed.";
                //        break;

                //    case ("missing-input-response"):
                //        ViewBag.Message = "The response parameter is missing.";
                //        break;
                //    case ("invalid-input-response"):
                //        ViewBag.Message = "The response parameter is invalid or malformed.";
                //        break;

                //    default:
                //        ViewBag.Message = "Error occured. Please try again";
                //        break;
                //}
            }

            return true;
        }
    }
}