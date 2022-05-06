using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository: Repository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext): base(dbContext){}
    }
}
