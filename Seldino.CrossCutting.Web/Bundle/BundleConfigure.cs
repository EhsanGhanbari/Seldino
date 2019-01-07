using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Seldino.CrossCutting.Web.Bundle
{
    public static class BundleConfigure
    {
        public static void Configure()
        {
            var assembly = Assembly.GetCallingAssembly();
            var bundlers = ResolveBundlers(assembly);
            bundlers.ToList().ForEach(b => b.Register());
        }

        public static IEnumerable<IBundleConfig> ResolveBundlers(Assembly assembly)
        {
            return from type in assembly.GetTypes()
                   where type.GetInterface(typeof(IBundleConfig).Name) != null
                   select Activator.CreateInstance(type) as IBundleConfig;
        }
    }
}
