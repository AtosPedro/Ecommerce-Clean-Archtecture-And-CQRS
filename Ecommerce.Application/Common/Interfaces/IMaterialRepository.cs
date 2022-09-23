using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IMaterialRepository
    {
        public Task<IEnumerable<Material>> GetAll(CancellationToken token);
        public Task<Material> GetById(int id, CancellationToken cancellationToken);
        public Task<Material> Add(Material material, CancellationToken token);
        public Task<Material> Update(Material material);
        public Task<Material> Remove(Material material);
    }
}
