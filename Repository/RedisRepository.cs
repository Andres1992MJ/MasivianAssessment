using Data;

namespace Repository
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IRedisData _redisData;
        public RedisRepository(IRedisData redisData)
        {
            _redisData = redisData;
        }
        public bool Set(string key, string value)
        {
            var db = _redisData.Connect();
            return db.StringSet(key, value);
        }
        public string Get(string key)
        {
            var db = _redisData.Connect();
            return db.StringGet(key);
        }
    }
}
