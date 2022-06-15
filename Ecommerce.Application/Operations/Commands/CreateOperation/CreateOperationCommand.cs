using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
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

        public async Task<Response<ReadOperationDto>> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Operation);

                if (!validationResult.IsValid)
                    return Response.Fail<ReadOperationDto>("The operation was not created", validationResult.ToErrorResponse());

                var operation = _mapper.Map<Operation>(request.Operation);
                var createdOperation = await _operationRepository.Add(operation);

                if (createdOperation == null)
                    return Response.Fail<ReadOperationDto>("The operation unit was not created", null);
                
                var readOperationDto = _mapper.Map<ReadOperationDto>(createdOperation);
                 
                await _unitOfWork.Commit();
                return Response.Ok(readOperationDto, "The operation was created with success");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<ReadOperationDto>("", errorResponse);
            }
        }
    }
}
