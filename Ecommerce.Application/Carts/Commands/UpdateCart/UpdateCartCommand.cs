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
        public Task<Response<ReadCartDto>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
