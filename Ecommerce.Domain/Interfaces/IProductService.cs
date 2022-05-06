using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
    }
}
