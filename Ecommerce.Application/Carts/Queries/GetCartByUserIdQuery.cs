using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;

namespace Ecommerce.Application.Carts.Queries
{
    public record GetCartByUserIdQuery : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public object Guid { get; set; }
    }

    public class GetCartByUserIdQueryHandler : IHandlerWrapper<GetCartByUserIdQuery, ReadCartDto>
    {
        public GetCartByUserIdQueryHandler()
        {

        }

        public async Task<Response<ReadCartDto>> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadCartDto>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
