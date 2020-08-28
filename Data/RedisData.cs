using Microsoft.Extensions.Configuration;
using Serilog;
using StackExchange.Redis;
using System;

namespace Data
{
    public class RedisData : IRedisData
    {
        private readonly string _redisHost;
        private readonly int _redisPort;
        public ConnectionMultiplexer redis;
        public RedisData(IConfiguration config)
        {
            _redisHost = config["Redis:Host"];
            _redisPort = Convert.ToInt32(config["Redis:Port"]);
        }
        public IDatabase Connect()
        {
            try
            {
                var configString = $"{_redisHost}:{_redisPort},connectRetry=5";
                redis = ConnectionMultiplexer.Connect(configString);
                Log.Debug("Connected to Redis");
                return redis.GetDatabase();
            }
            catch (RedisConnectionException err)
            {
                Log.Error(err.ToString());
                throw err;
            }
        }
    }
}
