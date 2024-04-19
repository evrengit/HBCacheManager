namespace HBApi.Common
{
    public interface ICacheManager
    {
        string Get(string key);

        void Set(string key, string value);
    }
}