using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ReadProductDto>> GetAll(CancellationToken token);
        public Task<ReadProductDto> GetById(string guid, CancellationToken cancellationToken);
        public Task<ReadProductDto> Create(CreateProductDto product, CancellationToken token);
        public Task<ReadProductDto> Update(UpdateProductDto product, CancellationToken cancellationToken);
        public Task<ReadProductDto> Delete(string guid, CancellationToken cancellationToken);
    }
}
