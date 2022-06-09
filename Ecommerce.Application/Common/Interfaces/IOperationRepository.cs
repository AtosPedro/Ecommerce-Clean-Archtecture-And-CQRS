using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>> GetAll();
        Task<Operation> GetById(int id);
        Task<Operation> Add(Operation operation);
        Task<Operation> Update(Operation operation);
        Task<Operation> Remove(Operation operation);
    }
}
