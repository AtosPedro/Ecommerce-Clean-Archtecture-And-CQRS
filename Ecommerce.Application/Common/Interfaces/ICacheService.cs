namespace Ecommerce.Application.Common.Interfaces
{
    public interface ICacheService
    {
        public Task<object> GetCacheValueAsync(string key);
        public Task<bool> SetCacheValueAsync(string key, object value);
    }
}
