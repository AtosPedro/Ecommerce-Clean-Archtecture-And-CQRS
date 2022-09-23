using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IMaterialService
    {
        public Task<IEnumerable<Material>> GetAll(CancellationToken token);
        public Task<Material> GetById(string id);
        public Task<Material> Add(Material material, CancellationToken token);
        public Task<Material> Update(Material material);
        public Task<Material> Remove(Material material);
    }
}
