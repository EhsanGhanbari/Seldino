using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;

namespace Seldino.Web.API.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            foreach (var formatter in configuration.Formatters)
            {
                Trace.WriteLine(formatter.GetType().Name);
            }
        }
    }
}