using Autofac;
using Seldino.CrossCutting.Caching;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using Seldino.Repository.Search;

namespace Seldino.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<Log4NetAdapter>().As<ILogger>().SingleInstance();
            builder.RegisterType<CacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().SingleInstance();
            builder.RegisterType<LuceneIndexProvider>().As<IIndexProvider>().SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.Name.EndsWith("Repository") && t.IsClass)
            .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
