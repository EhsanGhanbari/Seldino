using Autofac;

namespace Seldino.Application.Query
{
    public sealed class QueryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.Name.EndsWith("QueryService") && t.IsClass)
                .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
