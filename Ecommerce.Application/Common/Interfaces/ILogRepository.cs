using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ILogRepository
    {
        Task Add(Log log, Guid guid);
        Task<IEnumerable<Log>> GetAsync();
    }
}
