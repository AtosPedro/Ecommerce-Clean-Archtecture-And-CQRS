using Ecommerce.Application.Common.DTOs.Operations;
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

        #region Queries

        public Task<IEnumerable<ReadOperationDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> GetById(string guid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Commands

        public Task<Operation> Create(CreateOperationDto operation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> Delete(string guid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Operation> Update(UpdateOperationDto operation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
