using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Favorites;

namespace Ecommerce.Application.Favorites.Queries
{
    public record GetAllFavoritesQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadFavoriteDto>>
    {
    }

    public class GetAllFavoritesQueryHandler : IHandlerWrapper<GetAllFavoritesQuery, IEnumerable<ReadFavoriteDto>>
    {
        public GetAllFavoritesQueryHandler()
        {

        }

        public async Task<Response<IEnumerable<ReadFavoriteDto>>> Handle(GetAllFavoritesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadFavoriteDto>>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
