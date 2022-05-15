using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> Add(Supplier supplier);
        Task<Supplier> Update(Supplier supplier);
        Task<Supplier> Remove(Supplier supplier);
    }
}
