using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        public OperationRepository(IApplicationWriteDbContext writeContext, IApplicationReadDbContext readContext) : base(writeContext, readContext) { }
    }
}
