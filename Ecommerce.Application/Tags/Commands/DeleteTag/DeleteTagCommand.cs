using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Carts;

namespace Ecommerce.Application.Tags.Commands.DeleteTag
{
    public record DeleteTagCommand : BaseRequest, IRequestWrapper<ReadCartDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteTagCommandHandler : IHandlerWrapper<DeleteTagCommand, ReadCartDto>
    {
        public DeleteTagCommandHandler()
        {

        }

        public async Task<Response<ReadCartDto>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
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
