using StackExchange.Redis;

namespace Data
{
    public interface IRedisData
    {
        IDatabase Connect();
    }
}
