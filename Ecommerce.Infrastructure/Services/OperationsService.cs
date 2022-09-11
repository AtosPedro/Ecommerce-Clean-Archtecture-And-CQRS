using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly IOperationRepository _operationsRepository;
        private readonly IHashids _hashId;

        public OperationsService(IOperationRepository operationsRepository, IHashids hashId)
        {
            _operationsRepository = operationsRepository;
            _hashId = hashId;
        }

        public async Task<Operation> GetById(string hashId)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _operationsRepository.GetById(id[0]);
            return user;
        }

        public async Task<IEnumerable<Operation>> GetAll()
        {
            var operations = await _operationsRepository.GetAll();
            foreach (var operation in operations)
            {
                operation.Guid = _hashId.Encode(operation.Id);
            }

            return operations;
        }
    }
}
