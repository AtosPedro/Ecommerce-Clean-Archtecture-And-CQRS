using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext) : base(writeContext, readContext){}
    }
}
