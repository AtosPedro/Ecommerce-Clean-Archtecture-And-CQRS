using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext,
            ISyncService syncService) : base(writeContext, readContext, syncService) { }

        public override async Task<IEnumerable<Product>> GetAll(CancellationToken token)
        {
            SyncService.SyncWriteAndReadDBs();
            return await WriteContext.Products.AsNoTracking()
                .OrderBy(ob => ob.Name)
                .ToListAsync(token);
        }
    }
}
