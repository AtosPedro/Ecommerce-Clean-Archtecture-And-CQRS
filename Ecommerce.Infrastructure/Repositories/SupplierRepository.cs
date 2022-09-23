using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IApplicationWriteDbContext writeContext, IApplicationReadDbContext readContext) : base(writeContext, readContext) { }

        public override async Task<IEnumerable<Supplier>> GetAll(CancellationToken cancellationToken)
        {
            return await ReadContext.Suppliers
                .AsNoTracking()
                .Include(m => m.Materials)
                .OrderBy(ob => ob.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
