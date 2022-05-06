using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Context;

namespace Ecommerce.Infrastructure.Repositories
{
    public class StoreRepository: Repository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}
