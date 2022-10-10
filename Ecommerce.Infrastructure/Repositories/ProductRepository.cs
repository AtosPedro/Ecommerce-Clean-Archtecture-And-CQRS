using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IApplicationWriteDbContext writeContext, IApplicationReadDbContext readContext) : base(writeContext, readContext) {}

        public override async Task<IEnumerable<Product>> GetAll(CancellationToken token)
        {
            return await WriteContext.Products.AsNoTracking()
                .OrderBy(ob => ob.Name)
                .ToListAsync(token);
        }
    }
}
