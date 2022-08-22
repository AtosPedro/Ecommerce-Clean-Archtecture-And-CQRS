using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Operations.Queries
{
    public record GetOperationByIdQuery : BaseRequest, IRequestWrapper<ReadOperationDto>
    {
        public int OperationId { get; set; }
    }

    public class GetOperationByIdQueryHandler : IHandlerWrapper<GetOperationByIdQuery, ReadOperationDto>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public GetOperationByIdQueryHandler(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task<Response<ReadOperationDto>> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var operation = await _operationRepository.GetById(request.OperationId);

                if (operation == null)
                    throw new EntityNotFoundException("The operation was not found");

                var readOperationsDto = _mapper.Map<ReadOperationDto>(operation);
                return Response.Ok(readOperationsDto, "All operations");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };
                return Response.Fail<ReadOperationDto>("", errorResponse);
            }
        }
    }
}
