using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            this._context = context;
        }
        public Task<int> Commit()
        {
            return _context.SaveChangesAsync();
        }

        public Task<bool> RollBack()
        {
            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
