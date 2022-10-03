using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetCacheValueAsync<T>(string key) where T : Entity;
        Task<IEnumerable<T>> GetManyCacheValueAsync<T>() where T : Entity;
        Task<bool> SetCacheValueAsync<T>(string key, T value);
        Task RemoveCacheValueAsync<T>(string key);
    }
}
