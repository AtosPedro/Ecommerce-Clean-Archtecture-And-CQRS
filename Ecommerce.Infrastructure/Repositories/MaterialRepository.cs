using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(IApplicationDbContext context) : base(context){}

        public override async Task<IEnumerable<Material>> GetAll()
        {
            return await Context.Materials.AsNoTracking()
                .Include(ma => ma.Supplier)
                .OrderBy(ob => ob.Name)
                .ToListAsync();
        }
    }
}
