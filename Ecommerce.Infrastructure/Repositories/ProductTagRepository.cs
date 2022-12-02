using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductTagRepository : Repository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext) : base(writeContext, readContext){}
    }
}