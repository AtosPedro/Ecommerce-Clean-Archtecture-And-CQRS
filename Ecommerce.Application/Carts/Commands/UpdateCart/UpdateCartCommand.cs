using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;

namespace Ecommerce.Application.Carts.Commands.UpdateCart
{
    public record UpdateCartCommand : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public UpdateCartDto Cart { get; set; }
    }

    public class UpdateCartCommandHandler : IHandlerWrapper<UpdateCartCommand, ReadCartDto>
    {
        public async Task<Response<ReadCartDto>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
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
