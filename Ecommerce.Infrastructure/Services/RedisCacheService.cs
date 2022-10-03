using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Ecommerce.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;
        private readonly IServer _server;
        private readonly IConfiguration _configuration;

        public RedisCacheService(
            IConnectionMultiplexer connectionMultiplexer,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
            _server = _connectionMultiplexer.GetServer(_configuration.GetConnectionString("RedisConnection"));
        }

        public async Task<T> GetCacheValueAsync<T>(string key) where T : Entity
        {
            var cod = $"cod-{typeof(T).Name}-{key}";
            var redisObj = await _database.StringGetAsync(cod);

            if (String.IsNullOrEmpty(redisObj))
                return null;

            var result = JsonConvert.DeserializeObject<T>(redisObj);

            return result;
        }

        public async Task<IEnumerable<T>> GetManyCacheValueAsync<T>() where T : Entity
        {
            var cod = $"cod-{typeof(T).Name}-*";
            var redisObj = _server.KeysAsync(-1, cod);

            if (redisObj == null)
                return null;

            var cachedItems = new List<T>();
            await foreach (var key in redisObj)
            {
                string formattedKey = key.ToString()
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace($"cod-{typeof(T).Name}-", "");

                var item = await GetCacheValueAsync<T>(formattedKey);
                cachedItems.Add(item);
            }

            return cachedItems;
        }

        public async Task<bool> SetCacheValueAsync<T>(string key, T value)
        {
            var cod = $"cod-{typeof(T).Name}-{key}";

            string valueStr = JsonConvert.SerializeObject(value);

            if (String.IsNullOrEmpty(valueStr))
                return false;

            return await _database.StringSetAsync(cod, valueStr);
        }

        public async Task RemoveCacheValueAsync<T>(string key)
        {
            var cod = $"cod-{typeof(T).Name}-{key}";
            await _database.StringGetDeleteAsync(cod);
        }
    }
}
