using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ILogService
    {
        Task Info(Log log);
        Task<IEnumerable<Log>> GetAll();
    }
}
