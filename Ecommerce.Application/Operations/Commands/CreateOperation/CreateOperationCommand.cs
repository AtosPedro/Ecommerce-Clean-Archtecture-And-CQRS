using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Operations.Commands.CreateOperation
{
    public record CreateOperationCommand : BaseRequest, IRequestWrapper<ReadOperationDto>
    {
        public CreateOperationDto Operation { get; set; }
    }

    public class CreateOperationCommandHandler : IHandlerWrapper<CreateOperationCommand, ReadOperationDto>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateOperationValidator _validator;

        public CreateOperationCommandHandler(
            IOperationRepository operationRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = new CreateOperationValidator();
        }

        public async Task<Response<ReadOperationDto>> Handle(
            CreateOperationCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Operation);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadOperationDto>("The operation was not created", validationResult.ToErrorResponse());

                var operation = _mapper.Map<Operation>(request.Operation);
                await _operationRepository.Add(operation,cancellationToken);

                await _unitOfWork.Commit();
                var readOperationDto = _mapper.Map<ReadOperationDto>(operation);
                return Response.Ok(readOperationDto, "The operation was created with success");
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
