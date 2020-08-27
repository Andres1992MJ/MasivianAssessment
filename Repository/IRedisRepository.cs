namespace Repository
{
    public interface IRedisRepository
    {
        bool Set(string key, string value);
        string Get(string key);
    }
}
