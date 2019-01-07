using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.DocumentHandler;
using Seldino.Application.Query.DocumentService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class DocumentController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IDocumentQueryService _documentQueryService;

        public DocumentController(ICommandBus commandBus, IDocumentQueryService documentQueryService)
        {
            _commandBus = commandBus;
            _documentQueryService = documentQueryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var command = new AddDocumentCommand();
            FillSocialMediaOptions();
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Create(AddDocumentCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            ViewBag.Result = result;
            return View();
        }

        public ActionResult Edit(Guid documentId)
        {
            var response = _documentQueryService.GetDocumentById(new DocumentQueryRequest { DocumentId = documentId });

            if (response.Failed || response.Document == null)
            {
                return View("Edit");
            }

            FillSocialMediaOptions();
            var command = response.Document.ToCommand();
            return View("Edit", command);
        }


        [HttpPost]
        public ActionResult Edit(EditDocumentCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            ViewBag.Result = result;
            return View();
        }

        public void SavePicture(HttpPostedFileBase upload)
        {
            var httpPostedFileBase = new List<HttpPostedFileBase> { upload };
            var command = PreparePicture(httpPostedFileBase, DocumentPicturePath);
            SavePicture(command, DocumentPicturePath);
        }

        public ActionResult GetPictures()
        {
            var files = Directory.GetFiles(Server.MapPath(DocumentPicturePath));
            return View(files);
        }

        private void FillSocialMediaOptions()
        {
            var response = _documentQueryService.GetSocialMediaOptions(new SocialMediaQueryRequest());
            if (!response.Failed)
                ViewData["SocialMediaOptions"] = response.SocialMediaOptions;
        }
    }
}