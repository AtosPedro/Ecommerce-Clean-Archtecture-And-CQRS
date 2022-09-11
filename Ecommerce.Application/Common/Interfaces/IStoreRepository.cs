using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store> GetById(int id);
        Task<IEnumerable<Store>> GetAll();
        Task<Store> Add(Store store);
        Task<Store> Update(Store store);
        Task<Store> Remove(Store store);
    }
}
