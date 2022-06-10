using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Repositories
{
    public class LogFireBaseRepository : FireBaseRepository<Log>, ILogRepository {}
}
