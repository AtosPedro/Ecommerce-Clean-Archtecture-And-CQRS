using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ISupplierService
    {
        public Task<IEnumerable<Supplier>> GetAll(CancellationToken cancellationToken);
        public Task<Supplier> Add(Supplier supplier, CancellationToken cancellationToken);
        public Task<Supplier> Update(Supplier supplier);
        public Task<Supplier> Remove(Supplier supplier);
    }
}
