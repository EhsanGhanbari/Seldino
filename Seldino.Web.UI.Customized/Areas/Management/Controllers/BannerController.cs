using System;
using System.Web;
using System.Web.Mvc;
using Seldino.Application.Command.BannerHandler;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.BannerService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Areas.Management.Controllers
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

        [OutputCache(Duration = OutputCacheDuration)]
        public ActionResult List(int pageIndex)
        {
            var query = new BannersQueryRequest(pageIndex, PageSize, CurrentUser.Id);
            var response = _bannerQueryService.GetBanners(query);
            return View("List", response);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateBannerCommand command)
        {
            if (!ModelState.IsValid) return View("Create");
            var picture = PreparePicture(command.HttpPostedFileBase, BannerPicturePath);
            command.Picture = picture;
            command.UserId = CurrentUser.Id;
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
                //ShowAlert //ToDo
                return View("List");
            }

            var command = response.Banner.ToCommand();
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditBannerCommand command, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid) return View("Edit");
            var picture = PreparePicture(image, BannerPicturePath);
            command.Picture = picture;
            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(picture, BannerPicturePath);
            return JsonMessage(result);
        }

        /// <summary>
        /// returns all active banners of the current user
        /// </summary>
        /// <returns></returns>
        public ActionResult Active(int pageIndex)
        {
            var query = new BannersQueryRequest(pageIndex, PageSize);
            var response = _bannerQueryService.GetActiveBanners(query);
            return View("Active", response);
        }

        /// <summary>
        /// returns all inactive banners of the current user
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Inactive(int pageIndex)
        {
            var query = new BannersQueryRequest(pageIndex, PageSize);
            var response = _bannerQueryService.GetInactiveBanners(query);
            return View("Inactive", response);
        }

        [HttpPost]
        public ActionResult Activate(ActivateBannerCommand command)
        {
            var response = _commandBus.Send(command);
            return JsonMessage(response);
        }

        [HttpPost]
        public ActionResult Deactivate(DeactivateBannerCommand command)
        {
            var response = _commandBus.Send(command);
            return JsonMessage(response);
        }

        [HttpPost]
        public ActionResult Delete(DeleteBannerCommand command)
        {
            var response = _commandBus.Send(command);
            return JsonMessage(response);
        }
    }
}