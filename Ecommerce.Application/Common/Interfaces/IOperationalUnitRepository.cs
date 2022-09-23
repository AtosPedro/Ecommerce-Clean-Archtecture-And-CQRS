using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IOperationalUnitRepository
    {
        public Task<IEnumerable<OperationalUnit>> GetAll(CancellationToken token);
        public Task<OperationalUnit> GetById(int id, CancellationToken cancellationToken);
        public Task<OperationalUnit> Add(OperationalUnit operationalUnit, CancellationToken token);
        public Task<OperationalUnit> Update(OperationalUnit operationalUnit);
        public Task<OperationalUnit> Remove(OperationalUnit operationalUnit);
    }
}
