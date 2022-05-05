using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class StoreRepository: Repository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}
