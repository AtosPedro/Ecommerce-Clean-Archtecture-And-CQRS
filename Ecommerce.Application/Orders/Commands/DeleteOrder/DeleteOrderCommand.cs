using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Orders;

namespace Ecommerce.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand : BaseRequest, IRequestWrapper<ReadOrderDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteOrderCommandHandler : IHandlerWrapper<DeleteOrderCommand, ReadOrderDto>
    {
        public DeleteOrderCommandHandler()
        {

        }

        public async Task<Response<ReadOrderDto>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
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
