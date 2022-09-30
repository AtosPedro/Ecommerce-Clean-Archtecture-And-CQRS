using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IOperationService
    {
        public Task<IEnumerable<ReadOperationDto>> GetAll(CancellationToken cancellationToken);
        public Task<Operation> GetById(string guid, CancellationToken cancellationToken);
        public Task<Operation> Create(CreateOperationDto operation, CancellationToken cancellationToken);
        public Task<Operation> Update(UpdateOperationDto operation, CancellationToken cancellationToken);
        public Task<Operation> Delete(string guid, CancellationToken cancellationToken);
    }
}
