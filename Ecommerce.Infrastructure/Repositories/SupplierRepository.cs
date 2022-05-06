using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Context;

namespace Ecommerce.Infrastructure.Repositories
{
    public class SupplierRepository: Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
