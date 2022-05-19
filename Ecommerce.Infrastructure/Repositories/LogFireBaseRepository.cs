using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class LogFireBaseRepository : FireBaseRepository<Log>, ILogRepository {}
}
