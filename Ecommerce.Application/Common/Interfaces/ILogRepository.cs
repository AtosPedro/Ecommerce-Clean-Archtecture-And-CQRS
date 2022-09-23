using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ILogRepository
    {
        public Task Add(Log log, Guid guid);
        public Task<IEnumerable<Log>> GetAsync();
    }
}
