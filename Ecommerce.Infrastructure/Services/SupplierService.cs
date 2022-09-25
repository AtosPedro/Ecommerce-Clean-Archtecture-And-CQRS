using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        public Task<Supplier> Add(Supplier supplier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> Remove(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> Update(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
