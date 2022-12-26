using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Favorites;

namespace Ecommerce.Application.Favorites.Queries
{
    public record GetFavoriteByIdQuery : BaseRequest, IRequestWrapper<ReadFavoriteDto>
    {
        public string Guid { get; set; }
    }

    public class GetFavoriteByIdQueryHandler : IHandlerWrapper<GetFavoriteByIdQuery, ReadFavoriteDto>
    {
        public GetFavoriteByIdQueryHandler()
        {

        }

        public async Task<Response<ReadFavoriteDto>> Handle(GetFavoriteByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadFavoriteDto>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
