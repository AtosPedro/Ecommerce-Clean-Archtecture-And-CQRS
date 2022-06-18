using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Interfaces;

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
            var operations = await _operationRepository.GetById(request.OperationId);
            var readOperationsDto = _mapper.Map<ReadOperationDto>(operations);
            return Response.Ok(readOperationsDto, "All operations");
        }
    }
}
