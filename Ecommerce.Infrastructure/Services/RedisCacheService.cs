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

        public async Task<T> GetCacheValueAsync<T>(string key) where T : class
        {
            var cod = $"cod-{nameof(T)}-{key}";
            var redisObj = await _database.StringGetAsync(cod);

            if (String.IsNullOrEmpty(redisObj))
                return null;

            var result = JsonConvert.DeserializeObject<T>(redisObj);

            return result;
        }

        public async Task<bool> SetCacheValueAsync<T>(string key, T value)
        {
            var cod = $"cod-{nameof(T)}-{key}";

            string valueStr = JsonConvert.SerializeObject(value);

            if (String.IsNullOrEmpty(valueStr))
                return false;

            return await _database.StringSetAsync(cod, valueStr);
        }
    }
}
