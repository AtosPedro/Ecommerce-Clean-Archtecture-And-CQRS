namespace Ecommerce.Application.Common.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetCacheValueAsync<T>(string key) where T : class;
        Task<bool> SetCacheValueAsync<T>(string key, T value);
    }
}
