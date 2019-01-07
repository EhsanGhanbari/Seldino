using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public class StoreRoute : IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            //Sample: http://kadobin.com/Store
            routes.MapRoute(
                  name: RouteConstants.StoreList,
                   url: "Store",
                  defaults: new { controller = "Store", action = "List" },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/hutan
            routes.MapRoute(
                  name: RouteConstants.StoreListSearch,
                   url: "Store/{keyword}",
                  defaults: new { controller = "Store", action = "List" },
                  constraints: new
                  {
                      keyword = RegularExpressionConstants.EnglishAndPersianAlphanumeric
                  },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: TODO http://kadobin.com/Store/storeId
            routes.MapRoute(
                  name: RouteConstants.StoreDetail,
                  url: "Store/Detail/{storeId}",
                  defaults: new { controller = "Store", action = "Detail" },
                  constraints: new
                  {
                      storeId = RegularExpressionConstants.EnglishAlphabet
                  },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/BestSelling
            routes.MapRoute(
                  name: RouteConstants.StoreBestSelling,
                  url: "Store/BestSelling/Page/{PageIndex}",
                  defaults: new { controller = "Store", action = "BestSelling" },
                  constraints: new { PageIndex = RegularExpressionConstants.Numeric },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/BestSelling/sdf
            routes.MapRoute(
                  name: RouteConstants.StoreBestSellingSearch,
                  url: "Store/BestSelling/{keyword}/Page/{PageIndex}",
                  defaults: new { controller = "Store", action = "BestSelling" },
                  constraints: new
                  {
                      keyword = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                      PageIndex = RegularExpressionConstants.Numeric
                  },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/Discounted/Page/1
            routes.MapRoute(
                  name: RouteConstants.StoreDiscoutned,
                  url: "Store/Discounted/Page/{PageIndex}",
                  defaults: new { controller = "Store", action = "Discounted" },
                  constraints: new { PageIndex = RegularExpressionConstants.Numeric },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/Discounted/dfsdf/Page/2
            routes.MapRoute(
                  name: RouteConstants.StoreDiscoutnedSearch,
                  url: "Store/Discounted/{keyword}/Page/{PageIndex}",
                  defaults: new { controller = "Store", action = "Discounted" },
                  constraints: new
                  {
                      keyword = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                      PageIndex = RegularExpressionConstants.Numeric
                  },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/About/storeId
            routes.MapRoute(
                  name: RouteConstants.StoreAbout,
                   url: "Store/About/{storeId}",
                  defaults: new { controller = "Store", action = "About", id = UrlParameter.Optional },
                  constraints: new { controller = RegularExpressionConstants.EnglishAndPersianAlphanumeric },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/Guide/storeId
            routes.MapRoute(
                  name: RouteConstants.StoreGuide,
                   url: "Store/Guide/{storeId}",
                  defaults: new { controller = "Store", action = "Guide", id = UrlParameter.Optional },
                  constraints: new { controller = RegularExpressionConstants.EnglishAndPersianAlphanumeric },
                  namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Store/Information/storeId
            routes.MapRoute(
                name: RouteConstants.StoreInformation,
                 url: "Store/Information/{storeId}",
                defaults: new { controller = "Store", action = "Information", id = UrlParameter.Optional },
                constraints: new { controller = RegularExpressionConstants.EnglishAndPersianAlphanumeric },
                namespaces: new[] { RouteConstants.RoutingNamespace });

        }

        public int Priority => 2;
    }
}