using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IOperationService
    {
        public Task<IEnumerable<Operation>> GetAll(CancellationToken token);
        public Task<Operation> GetById(string id);
        public Task<Operation> Add(Operation operation, CancellationToken token);
        public Task<Operation> Update(Operation operation);
        public Task<Operation> Remove(Operation operation);
    }
}
