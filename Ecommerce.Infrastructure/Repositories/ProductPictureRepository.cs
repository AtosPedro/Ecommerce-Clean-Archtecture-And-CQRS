using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductPictureRepository : Repository<ProductPicture>, IProductPictureRepository
    {
        public ProductPictureRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext,
            ISyncService syncService) : base(writeContext, readContext, syncService) { }
    }
}
