using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;

namespace Ecommerce.Application.Carts.Commands.DeleteCart
{
    public record DeleteCartCommand : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteCartCommandHandler : IHandlerWrapper<DeleteCartCommand, ReadCartDto>
    {
        public async Task<Response<ReadCartDto>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
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
