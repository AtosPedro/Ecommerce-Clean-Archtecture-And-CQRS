using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(IApplicationWriteDbContext writeContext, IApplicationReadDbContext readContext) : base(writeContext, readContext) {}

        public override async Task<IEnumerable<Material>> GetAll(CancellationToken token)
        {
            return await WriteContext.Materials.AsNoTracking()
                .Include(ma => ma.Supplier)
                .OrderBy(ob => ob.Name)
                .ToListAsync(token);
        }
    }
}
