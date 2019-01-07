using System;
using System.Runtime.Caching;

namespace Seldino.CrossCutting.Caching
{
    public class CacheManager : ICacheManager
    {
        private const int DefaultCacheTime = 10;
        private ObjectCache Cache => MemoryCache.Default;

        public T Retrieve<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Cache[key] == null)
            {
                return default(T);
            }

            return (T)Cache[key];
        }

        public T Retrieve<T>(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Retrieve<T>(key, value, DefaultCacheTime);
        }

        public T Retrieve<T>(string key, object value, int cacheTimeInMinute)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Store(key, value, cacheTimeInMinute);

            return Retrieve<T>(key);
        }

        public void Store(string key, object value)
        {
            Store(key, value, DefaultCacheTime);
        }

        public void Store(string key, object value, int cacheTime)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            //  If value is null then, no need to save anything
            if (value == null)
            {
                return;
            }

            if (IsSet(key))
            {
                return;
            }

            var cacheItemPolicy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default,
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTime)
            };

            Cache.Add(key, value, cacheItemPolicy);
        }

        public void Reset(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            //  If value is null then, no need to save anything
            if (value == null)
            {
                return;
            }

            if (!IsSet(key))
            {
                return;
            }

            Cache[key] = value;
        }

        public bool IsSet(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Cache.Remove(key);
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
