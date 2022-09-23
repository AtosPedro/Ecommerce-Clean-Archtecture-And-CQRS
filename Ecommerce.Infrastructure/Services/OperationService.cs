using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationsRepository;
        private readonly IHashids _hashId;

        public OperationService(IOperationRepository operationsRepository, IHashids hashId)
        {
            _operationsRepository = operationsRepository;
            _hashId = hashId;
        }

        public async Task<Operation> GetById(string hashId, CancellationToken cancellationToken)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _operationsRepository.GetById(id[0], cancellationToken);
            return user;
        }

        public async Task<IEnumerable<Operation>> GetAll(CancellationToken cancellationToken)
        {
            var operations = await _operationsRepository.GetAll(cancellationToken);
            foreach (var operation in operations)
            {
                operation.Guid = _hashId.Encode(operation.Id);
            }

            return operations;
        }

        public Task<Operation> Add(Operation operation, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> Update(Operation operation)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> Remove(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}
