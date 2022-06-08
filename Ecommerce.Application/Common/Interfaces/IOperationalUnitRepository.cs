using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IOperationalUnitRepository
    {
        Task<IEnumerable<OperationalUnit>> GetAll();
        Task<OperationalUnit> Add(OperationalUnit supplier);
        Task<OperationalUnit> Update(OperationalUnit supplier);
        Task<OperationalUnit> Remove(OperationalUnit supplier);
    }
}
