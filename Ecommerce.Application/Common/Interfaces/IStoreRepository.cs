using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAll();
        Task<Store> Add(Store supplier);
        Task<Store> Update(Store supplier);
        Task<Store> Remove(Store supplier);
    }
}
