using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.StoreHandler;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
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
        public ActionResult List(string keyword)
        {
            var query = new StoresQueryRequest(keyword);
            var stores = _storeQueryService.GetStores(query);
            return View(stores);
        }

        /// <summary>
        /// returns inactive stores
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult Inactive(string keyword)
        {
            var query = new StoresQueryRequest(keyword);
            var stores = _storeQueryService.GetInactiveStores(query);
            return View(stores);
        }

        [HttpPost]
        public JsonResult Delete(DeleteStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return Json(result.Message);
        }

        [HttpPost]
        public JsonResult Activate(ActivateStoreCommand command)
        {
            var result = _commandBus.Send(command);
            return Json(result.Message);
        }
    }
}