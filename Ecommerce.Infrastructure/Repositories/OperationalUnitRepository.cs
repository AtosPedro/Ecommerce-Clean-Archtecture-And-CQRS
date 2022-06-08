using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OperationalUnitRepository : Repository<OperationalUnit>, IOperationalUnitRepository
    {
        public OperationalUnitRepository(IApplicationDbContext context) : base(context){}
    }
}
