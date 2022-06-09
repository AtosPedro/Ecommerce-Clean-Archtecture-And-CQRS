using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;

namespace Ecommerce.Application.Operations.Queries
{
    public record GetAllOperationsQuery : BaseRequest, IRequestWrapper<ReadOperationDto>{}

    public class GetAllOperationsQueryHandler : IHandlerWrapper<GetAllOperationsQuery, ReadOperationDto>
    {
        public Task<Response<ReadOperationDto>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
