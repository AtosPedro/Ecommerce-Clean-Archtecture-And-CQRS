using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;

namespace Ecommerce.Application.Operations.Queries
{
    public record GetOperationByIdQuery : BaseRequest, IRequestWrapper<ReadOperationDto>{}

    public class GetOperationByIdQueryHandler : IHandlerWrapper<GetOperationByIdQuery, ReadOperationDto>
    {
        public Task<Response<ReadOperationDto>> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
