using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll(CancellationToken token);
        public Task<Product> GetById(int id, CancellationToken cancellationToken);
        public Task<Product> Add(Product material, CancellationToken token);
        public Task<Product> Update(Product material);
        public Task<Product> Remove(Product material);
    }
}
