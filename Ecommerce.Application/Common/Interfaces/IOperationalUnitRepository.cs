using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IOperationalUnitRepository
    {
        Task<IEnumerable<OperationalUnit>> GetAll();
        Task<OperationalUnit> GetById(int id);
        Task<OperationalUnit> Add(OperationalUnit operationalUnit);
        Task<OperationalUnit> Update(OperationalUnit operationalUnit);
        Task<OperationalUnit> Remove(OperationalUnit operationalUnit);
    }
}
