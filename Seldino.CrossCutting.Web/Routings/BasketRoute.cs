using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public class BasketRoute: IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            //Sample: http://kadobin.com/Basket/Card
            routes.MapRoute(
                name: RouteConstants.BasketCard,
                url: "Basket/Card",
                defaults: new { controller = "basket", action = "Card" },
                namespaces: new[] { RouteConstants.RoutingNamespace });
        }

        public int Priority => 2;
    }
}