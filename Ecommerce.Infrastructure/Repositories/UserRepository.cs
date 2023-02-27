using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext,
            ISyncService syncService) : base(writeContext, readContext, syncService) { }
    }
}
