using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IStoreService
    {
        public Task<IEnumerable<Store>> GetAll(CancellationToken token);
        public Task<Store> GetById(string id, CancellationToken cancellationToken);
        public Task<Store> Add(Store store, CancellationToken token);
        public Task<Store> Update(Store store);
        public Task<Store> Remove(Store store);
    }
}
