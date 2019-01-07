using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Seldino.Application.Command;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.DocumentHandler;
using Seldino.Application.Query.DocumentService;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Areas.Management.Controllers
{
    public class DocumentController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IDocumentQueryService _documentQueryService;
        private readonly IStoreQueryService _storeQueryService;

        public DocumentController(ICommandBus commandBus, IDocumentQueryService documentQueryService, IStoreQueryService storeQueryService)
        {
            _commandBus = commandBus;
            _documentQueryService = documentQueryService;
            _storeQueryService = storeQueryService;
        }

        /// <summary>
        /// List of stores of the user will be showed
        /// to choose from inorder to fill document for
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var query = new StoresQueryRequest(CurrentUser.Id);
            var store = _storeQueryService.GetStores(query);
            return View("Index", store);
        }

        public ActionResult Create(Guid storeId)
        {
            var command = new AddDocumentCommand { StoreId = storeId };
            FillSocialMediaOptions();
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Create(AddDocumentCommand command)
        {
            if (!ModelState.IsValid)
            {
                FillSocialMediaOptions();
                return View("Create");
            }

            var result = _commandBus.Send(command);
            if (!result.Success) return JsonMessage(result);
            SavePicture(AddAboutPicture(command), DocumentPicturePath);
            SavePicture(AddGuidePicture(command), DocumentPicturePath);
            return JsonMessage(result);
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
            if (!ModelState.IsValid) return View("Edit");
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        private void FillSocialMediaOptions()
        {
            var response = _documentQueryService.GetSocialMediaOptions(new SocialMediaQueryRequest());
            if (!response.Failed)
                ViewData["SocialMediaOptions"] = response.SocialMediaOptions;
        }

        private IEnumerable<PictureCommand> AddAboutPicture(IDocumentCommand command)
        {
            var pictures = new List<PictureCommand>();

            if (command.AboutCommand.HttpPostedFileBases != null)
            {
                pictures = PreparePicture(command.AboutCommand.HttpPostedFileBases, DocumentPicturePath);
                command.AboutCommand.PictureCommands = pictures;
            }

            return pictures;
        }

        private IEnumerable<PictureCommand> AddGuidePicture(IDocumentCommand command)
        {
            var pictures = new List<PictureCommand>();

            if (command.GuideCommand.HttpPostedFileBases != null)
            {
                pictures = PreparePicture(command.AboutCommand.HttpPostedFileBases, DocumentPicturePath);
                command.GuideCommand.PictureCommands = pictures;
            }

            return pictures;
        }
    }
}