using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories
{
    public class SupplierRepository : RepositoryMySqlDb<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationMySqlDbContext context) : base(context){}
    }
}
