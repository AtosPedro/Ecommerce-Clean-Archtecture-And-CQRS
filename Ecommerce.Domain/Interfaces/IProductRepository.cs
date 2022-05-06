using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Add(Product entity);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Update(Product entity);
        Task<Product> Remove(Product entity);
        Task<IEnumerable<Product>> Search(Expression<Func<Product, bool>> predicate);
        Task<int> SaveChanges();
    }
}
