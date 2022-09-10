using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Operations.Commands.UpdateOperation
{
    public record UpdateOperationCommand : IRequestWrapper<ReadOperationDto>
    {
        public UpdateOperationDto Operation { get; set; }
    }

    public class UpdateOperationCommandHandler : IHandlerWrapper<UpdateOperationCommand, ReadOperationDto>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateOperationValidator _validator;

        public UpdateOperationCommandHandler(
            IOperationRepository operationRepository,
            IMapper maapper,
            IUnitOfWork unitOfWork)
        {
            _operationRepository = operationRepository;
            _mapper = maapper;
            _unitOfWork = unitOfWork;
            _validator = new UpdateOperationValidator();
        }

        public async Task<Response<ReadOperationDto>> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResponse = await _validator.ValidateAsync(request.Operation);
                if (!validationResponse.IsValid)
                    return Response.Fail<ReadOperationDto>("The operation was not created", validationResponse.ToErrorResponse());

                var operation = _mapper.Map<Operation>(request.Operation);
                await _operationRepository.Update(operation);

                var readOperationDto = _mapper.Map<ReadOperationDto>(operation);
                await _unitOfWork.Commit();
                return Response.Ok(readOperationDto, "The operation was not created");
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
                return Response.Fail<ReadOperationDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
