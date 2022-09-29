using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.OperationalUnits.Queries
{
    public record GetOperationalUnitByIdQuery : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>
    {
        public string Guid { get; set; }
    }

    public class GetOperationalUnitByIdQueryHandler : IHandlerWrapper<GetOperationalUnitByIdQuery, ReadOperationalUnitDto>
    {
        private readonly IOperationalUnitService _operationalUnitService;

        public GetOperationalUnitByIdQueryHandler(IOperationalUnitService operationalUnitRepository)
        {
            _operationalUnitService = operationalUnitRepository;
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(GetOperationalUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var readOperationalUnitDto = await _operationalUnitService.GetById(request.Guid, cancellationToken);
            return Response.Ok(readOperationalUnitDto, $"Operational unit with id {request.Guid}");
        }
    }
}
