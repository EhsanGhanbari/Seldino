using System;
using System.Web;
using System.Web.Mvc;
using Seldino.Application.Command.BannerHandler;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.BannerService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class BannerController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IBannerQueryService _bannerQueryService;

        public BannerController(ICommandBus commandBus, IBannerQueryService bannerQueryService)
        {
            _commandBus = commandBus;
            _bannerQueryService = bannerQueryService;
        }

        /// <summary>
        /// List of all banners in the system
        /// </summary>
        /// <returns></returns>

        public ActionResult List(int pageIndex, int pageSize)
        {
            var query = new BannersQueryRequest(pageSize, pageIndex);
            var response = _bannerQueryService.GetBanners(query);
            return View("List", response);
        }

        /// <summary>
        /// All inactive banners in the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Inactive(int pageIndex, int pageSize)
        {
            var query = new BannersQueryRequest(pageIndex, pageSize);
            var response = _bannerQueryService.GetInactiveBanners(query);
            return View("Inactive", response);
        }

        /// <summary>
        /// All active banners in the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Active(int pageIndex, int pageSize)
        {
            var query = new BannersQueryRequest(pageIndex, pageSize);
            var response = _bannerQueryService.GetActiveBanners(query);
            return View("Active", response);
        }

        /// <summary>
        /// All requested banners from managers to verify
        /// </summary>
        /// <returns></returns>
        public ActionResult UnConfirmed(int pageIndex, int pageSize)
        {
            var query = new BannersQueryRequest(pageIndex, pageSize);
            var response = _bannerQueryService.GetUnConfirmedBanners(query);
            return View("UnConfirmed", response);
        }

        [HttpPost]
        public JsonResult Confirm(ConfirmBannerCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateBannerCommand command, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid) return View("Create");
            var picture = PreparePicture(image, BannerPicturePath);
            command.Picture = picture;
            command.IsConfirmed = true;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(picture, BannerPicturePath);
            return JsonMessage(result);
        }

        public ActionResult Edit(Guid bannerId)
        {
            var response = _bannerQueryService.GetBannerDetailById(new BannerQueryRequest(bannerId));

            if (response.Failed || response.Banner == null)
            {
                return View("List");
            }

            var command = response.Banner.ToCommand();
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditBannerCommand command)
        {
            if (!ModelState.IsValid) return View("Edit");
            var picture = PreparePicture(command.HttpPostedFileBase, BannerPicturePath);
            command.Picture = picture;
            command.IsConfirmed = true;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(picture, BannerPicturePath);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Activate(ActivateBannerCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult Detail(Guid bannerId)
        {
            var request = new BannerQueryRequest(bannerId);
            var response = _bannerQueryService.GetBannerDetailById(request);
            return View("Detail", response);
        }

        [HttpPost]
        public JsonResult Deactivate(DeactivateBannerCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Delete(DeleteBannerCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}