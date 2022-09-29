using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IOperationalUnitService
    {
        public Task<IEnumerable<ReadOperationalUnitDto>> GetAll(CancellationToken cancellationToken);
        public Task<ReadOperationalUnitDto> GetById(string guid, CancellationToken cancellationToken);
        public Task<ReadOperationalUnitDto> Create(CreateOperationalUnitDto operationalUnit, CancellationToken cancellationToken);
        public Task<ReadOperationalUnitDto> Update(UpdateOperationalUnitDto operationalUnit, CancellationToken cancellationToken);
        public Task<ReadOperationalUnitDto> Delete(string guid, CancellationToken cancellationToken);
    }
}
