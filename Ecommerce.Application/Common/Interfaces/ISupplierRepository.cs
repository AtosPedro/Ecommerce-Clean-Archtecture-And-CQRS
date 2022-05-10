using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> Add(Supplier material);
        Task<Supplier> Update(Supplier material);
        Task<Supplier> Remove(Supplier material);
    }
}
