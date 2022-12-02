using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext) : base(writeContext, readContext){}
    }
}
