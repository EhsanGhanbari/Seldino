using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    internal class IgnoredRoutes : IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("bundles/{*pathInfo}");
            routes.IgnoreRoute("Pictures/{*pathInfo}");
            routes.IgnoreRoute("Fonts/{*pathInfo}");
            routes.IgnoreRoute(".db/{*virtualpath}");
        }

        public int Priority => 1;
    }
}
