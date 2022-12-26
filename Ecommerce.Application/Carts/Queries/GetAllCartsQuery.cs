using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;

namespace Ecommerce.Application.Carts.Queries
{
    public record GetAllCartsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadCartDto>>
    {
    }

    public class GetAllCartsQueryHandler : IHandlerWrapper<GetAllCartsQuery, IEnumerable<ReadCartDto>>
    {
        public async Task<Response<IEnumerable<ReadCartDto>>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadCartDto>>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
