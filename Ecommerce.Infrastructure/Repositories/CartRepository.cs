using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext) : base(writeContext, readContext){}
    }
}
