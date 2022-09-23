using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Operations.Commands.DeleteOperation
{
    public record DeleteOperationCommand : IRequestWrapper<bool>
    {
        public DeleteOperationDto DeleteOperationDto { get; set; }
    }

    class DeleteOperationCommandHandler : IHandlerWrapper<DeleteOperationCommand, bool>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DeleteOperationValidator _validator;

        public DeleteOperationCommandHandler(
            IOperationRepository operationRepository,
            IUnitOfWork unitOfWork)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
            _validator = new DeleteOperationValidator();
        }

        public async Task<Response<bool>> Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.DeleteOperationDto);
                if (!validationResult.IsValid)
                    return Response.Fail<bool>("The operation is invalid", validationResult.ToErrorResponse());

                var operation = await _operationRepository.GetById(request.DeleteOperationDto.Id, cancellationToken);
                var success = await _operationRepository.Remove(operation);

                await _unitOfWork.Commit();
                return Response.Ok(success != null, "The operation was deleted with sucess");
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = null;

                if (ex is ValidationException)
                {
                    var validationEx = ex as ValidationException;
                    errorResponse = validationEx?.ErrorResponse ?? new ErrorResponse();
                }
                else
                {
                    var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = $"Inner exception: {ex.InnerException}. Message: {ex.Message}" } };
                    errorResponse = new ErrorResponse { Errors = errors };
                }

                await _unitOfWork.RollBack();
                return Response.Fail<bool>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
