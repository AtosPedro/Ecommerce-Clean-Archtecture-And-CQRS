using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IApplicationDbContext context) : base(context){}

        public override async Task<IEnumerable<Supplier>> GetAll()
        {
            return await Context.Suppliers
                .AsNoTracking()
                .Include(m => m.Materials)
                .OrderBy(ob => ob.Name)
                .ToListAsync();
        }
    }
}
