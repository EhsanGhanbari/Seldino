namespace Seldino.CrossCutting.Caching
{
    public interface ICacheManager
    {
        T Retrieve<T>(string key);

        void Store(string key, object value);

        void Store(string key, object value, int cacheTime);

        void Reset(string key, object value);

        bool IsSet(string key);

        void Remove(string key);

        void Clear();
    }
}