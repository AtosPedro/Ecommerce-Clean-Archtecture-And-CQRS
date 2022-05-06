using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store> Add(Store entity);
        Task<IEnumerable<Store>> GetAll();
        Task<Store> GetById(int id);
        Task<Store> Update(Store entity);
        Task<Store> Remove(Store entity);
        Task<IEnumerable<Store>> Search(Expression<Func<Store, bool>> predicate);
        Task<int> SaveChanges();
    }
}
