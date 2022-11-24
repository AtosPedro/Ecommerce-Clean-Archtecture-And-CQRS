using Ecommerce.Application.Common.Communication;

namespace Ecommerce.Application.Carts.Commands.DeleteCart
{
    public record DeleteCartCommand : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteCartCommandHandler : IHandlerWrapper<DeleteCartCommand, ReadCartDto>
    {
        public Task<Response<ReadCartDto>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
