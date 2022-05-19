using FireSharp.Config;
using FireSharp.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public abstract class FireBaseRepository<T>
    {
        protected IFirebaseConfig _config;
        protected IFirebaseClient _client;

        public FireBaseRepository()
        {
            _config = new FirebaseConfig
            {
                AuthSecret = "x09rc9Cpv2OWy2MNM2YJ8CPF3hNhDILGMJ5iT14T",
                BasePath = "https://ecommercelogs-default-rtdb.firebaseio.com/"
            };

            _client = new FireSharp.FirebaseClient(_config);
        }

        public virtual async Task Add(T entity, Guid guid)
        {
            await _client.SetTaskAsync($"{typeof(T).Name}s/"+ guid.ToString(), entity);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            var result = await _client.GetTaskAsync($"{typeof(T).Name}s");
            return result.ResultAs<List<T>>();
        }

        public virtual async Task UpdateAsync(T entity, Guid guid)
        {
            await _client.UpdateTaskAsync($"{typeof(T).Name}s/" + guid.ToString(), entity);
        }

        public virtual async Task DeleteAsync(Guid guid)
        {
            await _client.DeleteTaskAsync($"{typeof(T).Name}s/" + guid.ToString());
        }
    }
}
