using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Operations.Commands.DeleteOperation
{
    public record DeleteOperationCommand : IRequestWrapper<bool>
    {
        public int OperationId { get; set; }
    }

    class DeleteOperationCommandHandler : IHandlerWrapper<DeleteOperationCommand, bool>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationCommandHandler(
            IOperationRepository operationRepository,
            IUnitOfWork unitOfWork)
        {
            this._operationRepository = operationRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.OperationId == 0)
                    throw new InvalidIdException("Invalid Id");

                var operation = await _operationRepository.GetById(request.OperationId);

                if (operation == null)
                    throw new EntityNotFoundException("The operation was not found");

                var success = await _operationRepository.Remove(operation);

                await _unitOfWork.Commit();
                return Response.Ok(success != null, "The operation was deleted with sucess");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<bool>("The operation was not deleted", errorResponse);
            }
        }
    }
}
