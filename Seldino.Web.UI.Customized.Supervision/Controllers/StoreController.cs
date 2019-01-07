using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.StoreHandler;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class StoreController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IStoreQueryService _storeQueryService;

        public StoreController(ICommandBus commandBus, IStoreQueryService storeQueryService)
        {
            _commandBus = commandBus;
            _storeQueryService = storeQueryService;
        }

        /// <summary>
        /// List of All stores 
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int pageIndex)
        {
            var query = new StoresQueryRequest(pageIndex, PageSize);
            var stores = _storeQueryService.GetStores(query);
            return View("List", stores);
        }

        /// <summary>
        /// returns inactive stores
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Inactive(int pageIndex)
        {
            var query = new StoresQueryRequest(pageIndex, PageSize);
            var stores = _storeQueryService.GetInactiveStores(query);
            return View("Inactive", stores);
        }

        [HttpPost]
        public JsonResult Delete(DeleteStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Activate(ActivateStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult Deactivate(DeactiveStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult Detail(Guid storeId)
        {
            var request = new StoreQueryRequest(storeId);
            var response = _storeQueryService.GetStoreById(request);
            return View("Detail", response);
        }
    }
}