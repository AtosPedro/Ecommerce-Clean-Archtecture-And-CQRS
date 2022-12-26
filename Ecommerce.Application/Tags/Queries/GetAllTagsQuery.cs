using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Tags;

namespace Ecommerce.Application.Tags.Queries
{
    public record GetAllTagsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadTagDto>>
    {
    }

    public class GetAllTagsQueryHandler : IHandlerWrapper<GetAllTagsQuery, IEnumerable<ReadTagDto>>
    {
        public GetAllTagsQueryHandler()
        {

        }

        public async Task<Response<IEnumerable<ReadTagDto>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadTagDto>>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
