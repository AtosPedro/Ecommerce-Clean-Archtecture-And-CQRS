using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Orders;

namespace Ecommerce.Application.Orders.Queries
{
    public record GetAllOrdersQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadOrderDto>>
    {
    }

    public class GetAllOrdersQueryHandler : IHandlerWrapper<GetAllOrdersQuery, IEnumerable<ReadOrderDto>>
    {
        public GetAllOrdersQueryHandler()
        {

        }

        public async Task<Response<IEnumerable<ReadOrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadOrderDto>>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
