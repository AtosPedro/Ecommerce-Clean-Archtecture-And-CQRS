using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public interface IOperationalUnitService
    {
        public Task<IEnumerable<OperationalUnit>> GetAll(CancellationToken token);
        public Task<OperationalUnit> GetById(string id);
        public Task<OperationalUnit> Add(OperationalUnit operationalUnit, CancellationToken token);
        public Task<OperationalUnit> Update(OperationalUnit operationalUnit);
        public Task<OperationalUnit> Remove(OperationalUnit operationalUnit);
    }
}
