using System;
using System.Web.Mvc;
using System.Web.UI;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.StoreHandler;
using Seldino.Application.Query.DocumentService;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class StoreController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IStoreQueryService _storeQueryService;
        private readonly IDocumentQueryService _documentQueryService;

        public StoreController(ICommandBus commandBus, IStoreQueryService storeQueryService, IDocumentQueryService documentQueryService)
        {
            _commandBus = commandBus;
            _storeQueryService = storeQueryService;
            _documentQueryService = documentQueryService;
        }

        #region Store

        /// <summary>
        /// List of stores sorted by value
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult List(string keyword)
        {
            var query = new StoresQueryRequest(keyword);
            var stores = _storeQueryService.GetStores(query);
            return View("List", stores);
        }

        /// <summary>
        /// Returns all about an store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Detail(Guid storeId)
        {
            var request = new StoreQueryRequest(storeId);
            var reponse = _storeQueryService.GetStoreById(request);
            return View("Detail", reponse);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult BestSellings()
        {
            var query = new StoresQueryRequest(1, 20);
            var response = _storeQueryService.GetStores(query);
            return PartialView("BestSellings", response);
        }

        /// <summary>
        /// List of best selling stores
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult BestSelling(int? pageIndex, string keyword)
        {
            var query = new StoresQueryRequest(pageIndex ?? 1, PageSize) { Keyword = keyword };
            var response = _storeQueryService.GetBestSellingStores(query);
            return View("BestSelling", response);
        }

        /// <summary>
        /// Returns all stores in discount period
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Discounted(int? pageIndex, string keyword)
        {
            var query = new StoresQueryRequest(pageIndex ?? 1, PageSize) { Keyword = keyword };
            var response = _storeQueryService.GetDiscountedStores(query);
            return View("Discounted", response);
        }

        #endregion

        #region Document

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult About(Guid storeId)
        {
            var about = Document(storeId).About;
            return View("About", about);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public PartialViewResult SocialMedia(Guid storeId)
        {
            var socialMedias = Document(storeId).SocialMedias;
            return PartialView("SocialMedia", socialMedias);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Rule(Guid storeId)
        {
            var rule = Document(storeId).Rule;
            return View("Rule", rule);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Guide(Guid storeId)
        {
            var guide = Document(storeId).Guide;
            return View("Guide", guide);
        }

        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Information(Guid storeId)
        {
            var information = Document(storeId).Information;
            return View("Information", information);
        }

        [NonAction]
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        private DocumentDto Document(Guid storeId)
        {
            return _documentQueryService.GetDocumentByStoreId(new DocumentQueryRequest
            {
                StoreId = storeId
            }).Document;
        }

        #endregion

        #region Comment

        [Authorize]
        public PartialViewResult CreateComment(Guid storeId)
        {
            ViewBag.StoreId = storeId;
            return PartialView("CreateComment");
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateComment(CreateStoreCommentCommand command)
        {
            if (!ModelState.IsValid) { return PartialView("CreateComment"); }
            command.UserId = CurrentUser.Id;
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [Authorize]
        public PartialViewResult ReplyToComment(Guid commentId)
        {
            ViewBag.CommentId = commentId;
            return PartialView("ReplyToComment");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ReplyToComment(ReplyToStoreCommentCommand command)
        {
            if (!ModelState.IsValid) { return PartialView("ReplyToComment"); }
            command.UserId = CurrentUser.Id;
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion
    }
}