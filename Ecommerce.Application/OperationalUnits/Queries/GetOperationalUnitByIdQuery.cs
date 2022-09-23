using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.OperationalUnits.Queries
{
    public record GetOperationalUnitByIdQuery : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>
    {
        public int OperationalUnitId { get; set; }
    }

    public class GetOperationalUnitByIdQueryHandler : IHandlerWrapper<GetOperationalUnitByIdQuery, ReadOperationalUnitDto>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IMapper _mapper;

        public GetOperationalUnitByIdQueryHandler(IOperationalUnitRepository operationalUnitRepository, IMapper mapper)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _mapper = mapper;
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(GetOperationalUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var operationalUnits = await _operationalUnitRepository.GetById(request.OperationalUnitId, cancellationToken);
            var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(operationalUnits);
            return Response.Ok(readOperationalUnitDto, $"Operational unit with id {request.OperationalUnitId}");
        }
    }
}
