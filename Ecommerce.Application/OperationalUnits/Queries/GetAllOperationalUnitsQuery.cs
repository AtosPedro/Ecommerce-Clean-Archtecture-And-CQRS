using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.OperationalUnits.Queries
{
    public record GetAllOperationalUnitsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadOperationalUnitDto>>{}

    public class GetAllOperationalUnitsQueryHandler : IHandlerWrapper<GetAllOperationalUnitsQuery, IEnumerable<ReadOperationalUnitDto>>
    {
        private readonly IOperationalUnitService _operationalUnitService;

        public GetAllOperationalUnitsQueryHandler(IOperationalUnitService operationalUnitRepository)
        {
            _operationalUnitService = operationalUnitRepository;
        }

        public async Task<Response<IEnumerable<ReadOperationalUnitDto>>> Handle(
            GetAllOperationalUnitsQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var readOperationalUnitsDto = await _operationalUnitService.GetAll(cancellationToken);
                return Response.Ok(readOperationalUnitsDto, "All operational units");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadOperationalUnitDto>>(
                    $"Fail to create a user. Message: {ex.Message}", 
                    ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
