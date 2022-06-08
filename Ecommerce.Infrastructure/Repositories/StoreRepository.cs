using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class StoreRepository : Repository<Store>
    {
        public StoreRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
