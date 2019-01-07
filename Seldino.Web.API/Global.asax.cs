using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using Seldino.Application.Command;
using Seldino.Application.Query;
using Seldino.CrossCutting.Web.Bundle;
using Seldino.Web.API.App_Start;

namespace Seldino.Web.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterServerConfiguration();
            RegisterBundleConfiguration();
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private static void RegisterServerConfiguration()
        {
            ConfigureAutofacConfiguration();
            ConfigureFluentValidation();
            MapperConfiguration.Configure();
        }

        private static void RegisterBundleConfiguration()
        {
            BundleConfigure.Configure();
        }

        private static void ConfigureFluentValidation()
        {
            FluentValidationModelValidatorProvider.Configure();
        }

        private static void ConfigureAutofacConfiguration()
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
