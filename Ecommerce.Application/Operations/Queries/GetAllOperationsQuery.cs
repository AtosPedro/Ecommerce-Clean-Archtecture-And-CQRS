using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Operations.Queries
{
    public record GetAllOperationsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadOperationDto>> {}

    public class GetAllOperationsQueryHandler : IHandlerWrapper<GetAllOperationsQuery, IEnumerable<ReadOperationDto>>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public GetAllOperationsQueryHandler(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadOperationDto>>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            var operations = await _operationRepository.GetAll();
            var readOperationsDto = _mapper.Map<IEnumerable<ReadOperationDto>>(operations);
            return Response.Ok(readOperationsDto, "All operations");
        }
    }
}
