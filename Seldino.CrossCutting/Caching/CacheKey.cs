using System;

namespace Seldino.CrossCutting.Caching
{
    public abstract class CacheKey<T> : CacheKey where T : class
    {
        protected CacheKey(T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            Source = source;
        }

        public T Source { get; private set; }
    }

    public abstract class CacheKey : ICacheKey
    {
    }

    public interface ICacheKey
    {
    }

    public interface ICachePolicy
    {
    }

    public interface ICachePolicy<in TCacheKey> : ICachePolicy where TCacheKey : ICacheKey
    {
    }
}