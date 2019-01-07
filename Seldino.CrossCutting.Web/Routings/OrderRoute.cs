using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public class OrderRoute : IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            //Sample: http://kadobin.com/Order/Pursuit/32
            routes.MapRoute(
                name: RouteConstants.OrderPursuit,
                url: "Order/Pursuit/{orderId}",
                defaults: new { controller = "Order", action = "Pursuit" },
                constraints: new { controller = RegularExpressionConstants.EnglishAndPersianAlphanumeric },
                namespaces: new[] { RouteConstants.RoutingNamespace });
        }

        public int Priority => 2;
    }
}