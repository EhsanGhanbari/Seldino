using System.Linq;
using System.Web.Routing;
using Seldino.CrossCutting.Utilities;
using Seldino.CrossCutting.Web.Routings;

namespace Seldino.Web.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
          //  routes.Canonicalize().Lowercase().TrailingSlash();

            var types = TypeHelper.GetDerivedTypes<IRouteConfigRegistery>().OrderBy(c => c.Priority);

            foreach (var type in types)
            {
                type.Register(routes);
            }

            routes.LowercaseUrls = true;
            routes.AppendTrailingSlash = true;


            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //     "Default",
            //     "{controller}/{action}/{id}",
            //     new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //     new[] { "Seldino.Web.UI.Customized.Controllers" }
            //);
        }
    }
}
