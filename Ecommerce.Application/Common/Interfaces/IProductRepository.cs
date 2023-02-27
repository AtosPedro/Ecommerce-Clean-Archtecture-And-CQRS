using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll(CancellationToken token);
        public Task<Product> GetById(int id, CancellationToken cancellationToken);
        public Task<Product> Add(Product product, CancellationToken token);
        public Task<Product> Update(Product product);
        public Task<Product> Remove(Product product);
    }
}
