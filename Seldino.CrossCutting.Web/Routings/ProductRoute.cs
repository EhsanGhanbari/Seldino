using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public class ProductRoute : IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            //ToDo
            //routes.MapRoute(
            //      name: RouteConstants.ProductDetail,
            //       url: "Product/{productId}",
            //      defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            //      constraints: new { controller = RegularExpressionConstants.EnglishAndPersianAlphanumeric },
            //      namespaces: new[] { "Seldino.Web.UI.Customized.Controllers" });


            //Sample: http://kadobin.com/Product/BestSelling/Page
            routes.MapRoute(
                name: RouteConstants.ProductBestSelling,
                url: "Product/BestSelling/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "BestSellings" },
                constraints: new
                {
                    pageIndex = RegularExpressionConstants.Numeric
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Product/Popular/Page
            routes.MapRoute(
                name: RouteConstants.ProductPopular,
                url: "Product/Popular/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "Populars" },
                constraints: new
                {
                    pageIndex = RegularExpressionConstants.Numeric
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });



            //Sample: http://kadobin.com/Product/MostVisited/Page
            routes.MapRoute(
                name: RouteConstants.ProductMostVisited,
                url: "Product/MostVisited/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "MostVisiteds" },
                constraints: new
                {
                    pageIndex = RegularExpressionConstants.Numeric
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Product/Discounted/Page
            routes.MapRoute(
                name: RouteConstants.ProductDiscounted,
                url: "Product/Discounted/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "Discounteds" },
                constraints: new
                {
                    pageIndex = RegularExpressionConstants.Numeric
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Product/ساعت/versace/Page/1
            routes.MapRoute(
                name: RouteConstants.ProductBrand,
                url: "Product/{category}/{brand}/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "Brand" },
                constraints: new
                {
                    category = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                    brand = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                    pageIndex = RegularExpressionConstants.Numeric,
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Product/ساعت/Page/1
            routes.MapRoute(
                name: RouteConstants.ProductCategory,
                url: "Product/{category}/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "Category" },
                constraints: new
                {
                    category = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                    pageIndex = RegularExpressionConstants.Numeric,
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Product/ساعت/new/Page/1
            routes.MapRoute(
                name: RouteConstants.ProductTag,
                url: "Product/{category}/{tag}/Page/{pageIndex}",
                defaults: new { controller = "Product", action = "Tag" },
                constraints: new
                {
                    category = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                    tag = RegularExpressionConstants.EnglishAndPersianAlphanumeric,
                    pageIndex = RegularExpressionConstants.Numeric,
                },
                namespaces: new[] { RouteConstants.RoutingNamespace });

        }

        public int Priority => 2;
    }
}