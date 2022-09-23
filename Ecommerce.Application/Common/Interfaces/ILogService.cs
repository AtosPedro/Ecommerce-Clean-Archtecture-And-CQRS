using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ILogService
    {
        public Task Info(Log log);
        public Task Error(Log log);
        public Task<IEnumerable<Log>> GetAll();
    }
}
