using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnit;

namespace Ecommerce.Application.OperationalUnits.Queries
{
    public record GetOperationalUnitByIdQuery : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>
    {
        public int OperationalUnitId { get; set; }
    }

    public class GetOperationalUnitByIdQueryHandler : IHandlerWrapper<GetOperationalUnitByIdQuery, ReadOperationalUnitDto>
    {
        public GetOperationalUnitByIdQueryHandler()
        {

        }

        public Task<Response<ReadOperationalUnitDto>> Handle(GetOperationalUnitByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
