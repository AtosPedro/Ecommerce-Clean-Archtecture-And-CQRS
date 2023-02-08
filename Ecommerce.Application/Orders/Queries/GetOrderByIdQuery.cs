using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Orders;

namespace Ecommerce.Application.Orders.Queries
{
    public record GetOrderByIdQuery : BaseRequest, IRequestWrapper<ReadOrderDto>
    {
        public string Guid { get; set; }
    }

    public class GetOrderByIdQueryHandler : IHandlerWrapper<GetOrderByIdQuery, ReadOrderDto>
    {
        public GetOrderByIdQueryHandler()
        {

        }

        public async Task<Response<ReadOrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadOrderDto>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
