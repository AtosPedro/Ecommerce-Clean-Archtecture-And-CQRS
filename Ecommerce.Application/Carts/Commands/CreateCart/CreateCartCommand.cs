using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;

namespace Ecommerce.Application.Carts.Commands.CreateCart
{
    public record CreateCartCommand : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public CreateCartDto Cart { get; set; }
    }

    public class CreateCartCommandHandler : IHandlerWrapper<CreateCartCommand, ReadCartDto>
    {
        public Task<Response<ReadCartDto>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}