using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Operations.Queries
{
    public record GetAllOperationsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadOperationDto>> {}

    public class GetAllOperationsQueryHandler : IHandlerWrapper<GetAllOperationsQuery, IEnumerable<ReadOperationDto>>
    {
        private readonly IOperationService _operationService;
        private readonly IMapper _mapper;

        public GetAllOperationsQueryHandler(IOperationService operationRepository, IMapper mapper)
        {
            _operationService = operationRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadOperationDto>>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var operations = await _operationService.GetAll(cancellationToken);
                var readOperationsDto = _mapper.Map<IEnumerable<ReadOperationDto>>(operations);
                return Response.Ok(readOperationsDto, "All operations");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };
                return Response.Fail<IEnumerable<ReadOperationDto>>("", errorResponse);
            }
        }
    }
}
