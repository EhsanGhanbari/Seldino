using Autofac;
using Seldino.Application.Command.CommandHandler;
using Seldino.Repository;

namespace Seldino.Application.Command
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerRequest();
            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerRequest();
        }
    }
}
