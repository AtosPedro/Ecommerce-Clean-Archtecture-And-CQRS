using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IOperationRepository
    {
        public Task<IEnumerable<Operation>> GetAll(CancellationToken token);
        public Task<Operation> GetById(int id, CancellationToken cancellationToken);
        public Task<Operation> Add(Operation operation, CancellationToken token);
        public Task<Operation> Update(Operation operation);
        public Task<Operation> Remove(Operation operation);
    }
}
