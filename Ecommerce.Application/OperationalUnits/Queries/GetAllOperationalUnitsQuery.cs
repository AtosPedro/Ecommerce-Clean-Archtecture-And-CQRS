using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;

namespace Ecommerce.Application.OperationalUnits.Queries
{
    public record GetAllOperationalUnitsQuery : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>{}

    public class GetAllOperationalUnitsQueryHandler : IHandlerWrapper<GetAllOperationalUnitsQuery, ReadOperationalUnitDto>
    {
        public GetAllOperationalUnitsQueryHandler()
        {

        }

        public Task<Response<ReadOperationalUnitDto>> Handle(GetAllOperationalUnitsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
