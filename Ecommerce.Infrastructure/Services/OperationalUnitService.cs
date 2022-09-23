using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class OperationalUnitService : IOperationalUnitService
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IHashids _hashId;
        public OperationalUnitService(IOperationalUnitRepository operationalUnitRepository, IHashids hashId)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _hashId = hashId;
        }

        public async Task<OperationalUnit> GetById(string hashId, CancellationToken cancellationToken)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _operationalUnitRepository.GetById(id[0], cancellationToken);
            return user;
        }

        public async Task<IEnumerable<OperationalUnit>> GetAll(CancellationToken cancellationToken)
        {
            var operationalUnits = await _operationalUnitRepository.GetAll(cancellationToken);
            foreach (var units in operationalUnits)
            {
                units.Guid = _hashId.Encode(units.Id);
            }

            return operationalUnits;
        }

        public Task<OperationalUnit> Add(OperationalUnit operationalUnit, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<OperationalUnit> Update(OperationalUnit operationalUnit)
        {
            throw new NotImplementedException();
        }

        public Task<OperationalUnit> Remove(OperationalUnit operationalUnit)
        {
            throw new NotImplementedException();
        }
    }
}
