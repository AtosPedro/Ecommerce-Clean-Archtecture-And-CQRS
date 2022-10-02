using Ecommerce.Application.Common.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Ecommerce.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
        }

        public async Task<object> GetCacheValueAsync<T>(string key) where T : class
        {
            var redisObj = await _database.StringGetAsync(key);

            if (String.IsNullOrEmpty(redisObj))
                return null;

            return JsonConvert.DeserializeObject(redisObj) as T;
        }

        public async Task<bool> SetCacheValueAsync<T>(string key, T value)
        {
            var cod = $"cod-{typeof(T)}-{key}";

            string valueStr = JsonConvert.SerializeObject(value);

            if (String.IsNullOrEmpty(valueStr))
                return false;

            return await _database.StringSetAsync(cod, valueStr);
        }
    }
}
