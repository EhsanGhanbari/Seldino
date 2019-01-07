using System;
using System.Collections.Generic;
using System.Linq;

namespace Seldino.CrossCutting.Utilities
{
    public static class TypeHelper
    {
        public static IEnumerable<T> GetDerivedTypes<T>()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(T).IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface && p.IsClass);

            return types.Select(task => (T)Activator.CreateInstance(task));
        }
    }
}
