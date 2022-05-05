using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Application.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> Add(Supplier entity);
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task<Supplier> Update(Supplier entity);
        Task<Supplier> Remove(Supplier entity);
        Task<IEnumerable<Supplier>> Search(Expression<Func<Supplier, bool>> predicate);
        Task<int> SaveChanges();
    }
}
