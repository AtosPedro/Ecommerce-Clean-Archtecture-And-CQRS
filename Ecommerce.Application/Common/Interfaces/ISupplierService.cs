using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ISupplierService
    {
        public Task<ReadSupplierDto> GetById(string Guid, CancellationToken cancellationToken);
        public Task<IEnumerable<ReadSupplierDto>> GetAll(CancellationToken cancellationToken);
        public Task<ReadSupplierDto> Create(CreateSupplierDto supplier, CancellationToken cancellationToken);
        public Task<ReadSupplierDto> Update(UpdateSupplierDto supplier, CancellationToken cancellationToken);
        public Task<ReadSupplierDto> Delete(string Guid, CancellationToken cancellationToken);
    }
}
