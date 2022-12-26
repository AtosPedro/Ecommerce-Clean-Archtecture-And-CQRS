using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Tags;

namespace Ecommerce.Application.Tags.Commands.CreateTag
{
    public record CreateTagCommand : BaseRequest, IRequestWrapper<ReadTagDto>
    {
        public CreateTagDto Tag { get; set; }
    }

    public class CreateTagCommandHandler : IHandlerWrapper<CreateTagCommand, ReadTagDto>
    {
        public CreateTagCommandHandler()
        {

        }

        public async Task<Response<ReadTagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadTagDto>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
