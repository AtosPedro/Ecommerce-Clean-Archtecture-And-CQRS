using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Orders;

namespace Ecommerce.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand : BaseRequest, IRequestWrapper<ReadOrderDto>
    {
        public UpdateOrderDto Order { get; set; }
    }

    public class UpdateOrderCommandHandler : IHandlerWrapper<UpdateOrderCommand, ReadOrderDto>
    {
        public UpdateOrderCommandHandler()
        {

        }

        public async Task<Response<ReadOrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
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
