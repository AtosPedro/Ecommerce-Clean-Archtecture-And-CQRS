using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Carts.Commands.CreateCart
{
    public record CreateCartCommand : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public CreateCartDto Cart { get; set; }
    }

    public class CreateCartCommandHandler : IHandlerWrapper<CreateCartCommand, ReadCartDto>
    {
        public CreateCartCommandHandler()
        {

        }

        public async Task<Response<ReadCartDto>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
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