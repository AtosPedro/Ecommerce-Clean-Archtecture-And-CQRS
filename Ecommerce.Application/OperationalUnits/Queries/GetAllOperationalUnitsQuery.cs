using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.OperationalUnits.Queries
{
    public record GetAllOperationalUnitsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadOperationalUnitDto>>{}

    public class GetAllOperationalUnitsQueryHandler : IHandlerWrapper<GetAllOperationalUnitsQuery, IEnumerable<ReadOperationalUnitDto>>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IMapper _mapper;

        public GetAllOperationalUnitsQueryHandler(
            IOperationalUnitRepository operationalUnitRepository, 
            IMapper mapper)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadOperationalUnitDto>>> Handle(GetAllOperationalUnitsQuery request, CancellationToken cancellationToken)
        {
            var operationalUnits = await _operationalUnitRepository.GetAll();
            var readOperationalUnitsDto = _mapper.Map<IEnumerable<ReadOperationalUnitDto>>(operationalUnits);
            return Response.Ok(readOperationalUnitsDto, "All operational units");
        }
    }
}
