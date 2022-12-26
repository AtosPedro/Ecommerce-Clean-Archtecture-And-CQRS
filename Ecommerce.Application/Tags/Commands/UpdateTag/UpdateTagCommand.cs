using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Tags;

namespace Ecommerce.Application.Tags.Commands.UpdateTag
{
    public record UpdateTagCommand : BaseRequest, IRequestWrapper<ReadTagDto>
    {
        public UpdateTagDto Tag { get; set; }
    }

    public class UpdateTagCommandHandler : IHandlerWrapper<UpdateTagCommand, ReadTagDto>
    {
        public UpdateTagCommandHandler()
        {

        }

        public async Task<Response<ReadTagDto>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
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
