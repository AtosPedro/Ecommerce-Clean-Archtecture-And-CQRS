using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Tags;

namespace Ecommerce.Application.Tags.Queries
{
    public record GetTagByIdQuery : BaseRequest, IRequestWrapper<ReadTagDto>
    {
        public string Guid { get; set; }
    }

    public class GetTagByIdQueryHandler : IHandlerWrapper<GetTagByIdQuery, ReadTagDto>
    {
        public GetTagByIdQueryHandler()
        {

        }

        public async Task<Response<ReadTagDto>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
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
