using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class LogFireBaseRepository : ILogRepository
    {
        private IFirebaseConfig _config;
        private IFirebaseClient _client;

        public LogFireBaseRepository()
        {
            _config = new FirebaseConfig
            {
                AuthSecret = "x09rc9Cpv2OWy2MNM2YJ8CPF3hNhDILGMJ5iT14T",
                BasePath = "https://ecommercelogs-default-rtdb.firebaseio.com/"
            };

            _client = new FirebaseClient(_config);
        }

        public async Task Add(Log log)
        {
            await _client.SetAsync($"Logs", log);
        }

        public async Task<Log> GetAsync(Log log)
        {
            var result = await _client.SetAsync($"Logs", log);
            return result.ResultAs<Log>();
        }

        public async Task UpdateAsync(Log log)
        {
            await _client.UpdateAsync($"Logs", log);
        }

        public async Task DeleteAsync(Log log)
        {
            await _client.DeleteAsync($"Logs");
        }
    }
}
