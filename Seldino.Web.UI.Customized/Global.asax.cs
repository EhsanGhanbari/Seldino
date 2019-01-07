using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using Seldino.Application.Command;
using Seldino.Application.Query;
using Seldino.CrossCutting.Authentication;
using Seldino.CrossCutting.Web.Bundle;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace Seldino.Web.UI
{
    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {
            RegisterRazorViewEngine();
            RegisterSystemConfiguration();

            BundleConfigure.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs eventArgs)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null) return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var serializer = new JavaScriptSerializer();
            if (authTicket == null) return;
            var serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

            var newUser = new CustomPrincipal(authTicket.Name)
            {
                Id = serializeModel.Id,
                Name = serializeModel.Name,
                Email = serializeModel.Email
            };

            HttpContext.Current.User = newUser;
        }

        private static void RegisterRazorViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        private static void RegisterSystemConfiguration()
        {
            ConfigureAutofac();
            FluentValidationModelValidatorProvider.Configure();
            MapperConfiguration.Configure();
        }

        private static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<QueryModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
