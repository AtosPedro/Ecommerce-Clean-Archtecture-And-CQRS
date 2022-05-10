using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class MaterialRepository : RepositoryMySqlDb<Material>, IMaterialRepository
    {
        public MaterialRepository(ApplicationMySqlDbContext context) : base(context){}

        public override async Task<IEnumerable<Material>> GetAll()
        {
            return await Context.Materials.AsNoTracking()
                .OrderBy(ob => ob.Name)
                .ToListAsync();
        }
    }
}
