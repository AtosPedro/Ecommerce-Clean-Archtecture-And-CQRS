using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IMaterialService
    {
        public Task<IEnumerable<ReadMaterialDto>> GetAll(CancellationToken token);
        public Task<ReadMaterialDto> GetById(string guid, CancellationToken cancellationToken);
        public Task<ReadMaterialDto> Create(CreateMaterialDto material, CancellationToken token);
        public Task<ReadMaterialDto> Update(UpdateMaterialDto material, CancellationToken cancellationToken);
        public Task<ReadMaterialDto> Delete(string guid, CancellationToken cancellationToken);
    }
}
