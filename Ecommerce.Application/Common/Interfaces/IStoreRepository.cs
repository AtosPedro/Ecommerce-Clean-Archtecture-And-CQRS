using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IStoreRepository
    {
        public Task<IEnumerable<Store>> GetAll(CancellationToken token);
        public Task<Store> GetById(int id, CancellationToken cancellationToken);
        public Task<Store> Add(Store store, CancellationToken token);
        public Task<Store> Update(Store store);
        public Task<Store> Remove(Store store);
    }
}
