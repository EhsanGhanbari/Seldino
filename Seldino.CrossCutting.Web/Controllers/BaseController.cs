using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Seldino.Application.Command;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.CrossCutting.Authentication;
using Seldino.CrossCutting.Queries;
using Seldino.CrossCutting.Utilities;
using Seldino.CrossCutting.Web.Helpers;

namespace Seldino.CrossCutting.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Basic 

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        #endregion

        #region Properties

        protected virtual string ProductPicturePath => "~/Pictures/Product/";

        protected virtual string ProductThumbPicturePath => "~/Pictures/Product/Thumb/";

        protected virtual string ProductIconPath => "~/Pictures/Product/Icon/";

        protected virtual string ProductIconThumbPath => "~/Pictures/Product/Icon/Thumb";

        protected virtual string BannerPicturePath => "~/Pictures/Banner/";

        protected virtual string BannerThumbPicturePath => "~/Pictures/Banner/Thumb/";

        public virtual string DocumentPicturePath => "~/Pictures/Document/";

        public virtual string DocumentThumbPicturePath => "~/Pictures/Document/";

        public virtual string MembershipPicturePath => "~/Pictures/Membership/";

        public virtual string StorePicturePath => "~/Pictures/Store/";

        public virtual string StoreThumbPicturePath => "~/Pictures/Store/Thumb/";

        protected const int PageSize = 10;
        protected const int ImageSize = 512;
        protected const int ImageThumbnailSize = 256;
        protected const int OutputCacheDuration = 6000;
        protected const string KadobinCookieId = "KadobinCookieId";

        #endregion

        #region Json Response

        protected JsonResult JsonMessage(ICommandResult result)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonMessage(QueryResponse response)
        {
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonMessage(string message)
        {
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonMessage(ICommandResult result, string singularMessage, string pluralMessage, int itemsCount)
        {
            var message = itemsCount > 1 ? pluralMessage : singularMessage;
            return Json(result, message, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Authentication

        protected virtual CustomPrincipal CurrentUser => HttpContext.User as CustomPrincipal;

        protected virtual IUserIdentity CurrentUserIdentity => new UserIdentity
        {
            Id = CurrentUser.Id,
            Email = CurrentUser.Email,
            Name = CurrentUser.Name ?? ""
        };

        protected ActionResult RedirectToAccessDenied()
        {
            return Redirect("~/Error/AccessDenied.html");
        }

        protected ActionResult RedirectToLogin()
        {
            return ControllerContext.IsChildAction ? null : RedirectToAction("SignIn", "Account");
        }

        protected void SerializeModel(CustomPrincipalSerializeModel serializeModel)
        {
            var serializer = new JavaScriptSerializer();
            var userData = serializer.Serialize(serializeModel);
            var authenticationTicket = new FormsAuthenticationTicket(1, serializeModel.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }

        #endregion

        #region Picture

        /// <summary>
        /// allowed extensions: ".gif", ".jpg", ".jpeg", ".png", ".bmp"
        /// </summary>
        /// <param name="httpPostedFileBase"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        protected PictureCommand PreparePicture(HttpPostedFileBase httpPostedFileBase, string path)
        {
            var picture = new PictureCommand();
            {
                var file = Path.GetExtension(httpPostedFileBase.FileName);
                if (file == null) return picture;
                var extension = file.ToLower();
                var fileName = Guid.NewGuid() + extension;
                picture = new PictureCommand { Name = fileName, Address = path, HttpPostedFileBase = httpPostedFileBase };
            }

            return picture;
        }

        protected List<PictureCommand> PreparePicture(IEnumerable<HttpPostedFileBase> httpPostedFileBases, string path)
        {
            var pictures = new List<PictureCommand>();
            var postedFileBases = httpPostedFileBases as HttpPostedFileBase[] ?? httpPostedFileBases.ToArray();

            foreach (var image in postedFileBases.Where(c => c != null))
            {
                if (image.ContentLength <= 0) continue;
                var file = Path.GetExtension(image.FileName);
                if (file == null) continue;
                var extension = file.ToLower();
                var fileName = Guid.NewGuid() + extension;
                pictures.Add(new PictureCommand { Name = fileName, Address = path, HttpPostedFileBase = image });
            }

            return pictures;
        }

        protected void SavePicture(PictureCommand command, string path)
        {
            if (command == null) return;
            var finalPath = Path.Combine(Server.MapPath(path), command.Name);
            command.HttpPostedFileBase.SaveAs(finalPath);
            ImageProcessing.CreateThumbnail(finalPath, Server.MapPath(path + "Thumb/"), ImageThumbnailSize, ImageThumbnailSize);
        }

        protected void SavePicture(IEnumerable<PictureCommand> commands, string path)
        {
            foreach (var file in commands)
            {
                var finalPath = Path.Combine(Server.MapPath(path), file.Name);
                file.HttpPostedFileBase.SaveAs(finalPath);
                ImageProcessing.CreateThumbnail(finalPath, Server.MapPath(path + "Thumb/"), ImageThumbnailSize, ImageThumbnailSize);
            }
        }

        #endregion
    }
}
