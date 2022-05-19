using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Common.Interfaces
{
    public interface ILogRepository
    {
        Task Add(Log log, Guid guid);
        Task<IEnumerable<Log>> GetAsync();
    }
}
