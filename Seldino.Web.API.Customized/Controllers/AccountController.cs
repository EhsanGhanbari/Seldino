using System.Net;
using System.Net.Http;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ICommandBus _commandBus;
        private readonly IMembershipQueryService _membershipQueryService;

        private AccountController(ICommandBus commandBus, IMembershipQueryService membershipQueryService)
        {
            _commandBus = commandBus;
            _membershipQueryService = membershipQueryService;
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage Register(RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var result = _commandBus.Send(command);
            return Request.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.ExpectationFailed);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage SignIn(AuthenticateQueryRequest request)
        {
            var response = _membershipQueryService.Authenticate(request);

            if (!response.Failed)
            {
                return Request.CreateResponse(!response.Failed ? HttpStatusCode.OK : HttpStatusCode.ExpectationFailed);
            }

            return Request.CreateResponse(!response.Failed ? HttpStatusCode.OK : HttpStatusCode.ExpectationFailed);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage ForgotPassword(SendPasswordRecoveryLinkCommand command)
        {
            if (!ModelState.IsValid) return Request.CreateResponse();

            var result = _commandBus.Send(command);

            if (result.Success)
            {
                return Request.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.ExpectationFailed);
            }

            return Request.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.ExpectationFailed);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage SignOut()
        {
            return Request.CreateResponse();
        }
    }
}