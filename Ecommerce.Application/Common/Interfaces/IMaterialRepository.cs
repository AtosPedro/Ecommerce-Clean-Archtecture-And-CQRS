using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAll();
        Task<Material> Add(Material material);
        Task<Material> Update(Material material);
        Task<Material> Remove(Material material);
    }
}
