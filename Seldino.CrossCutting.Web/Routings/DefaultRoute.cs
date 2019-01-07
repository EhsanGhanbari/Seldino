using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public class DefaultRoute : IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional },
             constraints: new { controller = RegularExpressionConstants.EnglishAlphabet },
             namespaces: new[] { RouteConstants.RoutingNamespace });
        }

        public int Priority => 3;
    }
}
