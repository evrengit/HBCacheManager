using System.Collections.Concurrent;

namespace HBApi.Common
{
    public class CacheManager : ICacheManager
    {
        private readonly ConcurrentDictionary<string, string> keys = [];

        public CacheManager()
        {
        }

        public void Set(string key, string value)
        {
            keys[key] = value;
        }

        public string Get(string key)
        {
            if (!keys.ContainsKey(key))
            {
                return string.Empty;
            }

            return keys[key];
        }
    }
}