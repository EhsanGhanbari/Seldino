using System.Web.Mvc;
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public class MembershipRoute:IRouteConfigRegistery
    {
        public void Register(RouteCollection routes)
        {
            //Sample: http://kadobin.com/Account/SignIn
            routes.MapRoute(
                name: RouteConstants.MembershipSignIn,
                url: "Account/SignIn",
                defaults: new { controller = "Account", action = "SignIn" },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Account/SignOut
            routes.MapRoute(
                name: RouteConstants.MembershipSignOut,
                url: "Account/SignOut",
                defaults: new { controller = "Account", action = "SignOut" },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Account/ForgotPassword
            routes.MapRoute(
                name: RouteConstants.MembershipForgotPassword,
                url: "Account/ForgotPassword",
                defaults: new { controller = "Account", action = "ForgotPassword" },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Account/UpdateProfile
            routes.MapRoute(
                name: RouteConstants.MembershipUpdateProfile,
                url: "Account/UpdateProfile",
                defaults: new { controller = "Account", action = "UpdateProfile" },
                namespaces: new[] { RouteConstants.RoutingNamespace });


            //Sample: http://kadobin.com/Account/ChangePassword
            routes.MapRoute(
                name: RouteConstants.MembershipChangePassword,
                url: "Account/ChangePassword",
                defaults: new { controller = "Account", action = "ChangePassword" },
                namespaces: new[] { RouteConstants.RoutingNamespace });

        }

        public int Priority => 2;
    }
}