using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IStoreService
    {
        public Task<IEnumerable<ReadStoreDto>> GetAll(CancellationToken cancellationToken);
        public Task<ReadStoreDto> GetById(string guid, CancellationToken cancellationToken);
        public Task<ReadStoreDto> Create(CreateStoreDto createStoreDto, CancellationToken cancellationToken);
        public Task<ReadStoreDto> Update(UpdateStoreDto updateStoreDto, CancellationToken cancellationToken);
        public Task<ReadStoreDto> Delete(string guid, CancellationToken cancellationToken);
    }
}
