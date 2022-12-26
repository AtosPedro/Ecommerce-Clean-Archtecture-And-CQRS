using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Orders;

namespace Ecommerce.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand : BaseRequest, IRequestWrapper<ReadOrderDto>
    {
        public CreateOrderDto Order { get; set; }
    }

    public class CreateOrderCommandHandler : IHandlerWrapper<CreateOrderCommand, ReadOrderDto>
    {
        public CreateOrderCommandHandler()
        {

        }

        public async Task<Response<ReadOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
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
