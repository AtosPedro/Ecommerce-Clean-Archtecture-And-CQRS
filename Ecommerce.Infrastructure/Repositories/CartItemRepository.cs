using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext,
            ISyncService syncService) : base(writeContext, readContext, syncService) { }
    }
}
