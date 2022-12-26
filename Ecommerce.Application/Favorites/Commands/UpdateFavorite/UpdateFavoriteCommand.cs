using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Favorites;

namespace Ecommerce.Application.Favorites.Commands.UpdateFavorite
{
    public record UpdateFavoriteCommand : BaseRequest, IRequestWrapper<ReadFavoriteDto>
    {
        public UpdateFavoriteDto Favorite { get; set; }

    }

    public class UpdateFavoriteCommandHandler : IHandlerWrapper<UpdateFavoriteCommand, ReadFavoriteDto>
    {
        public UpdateFavoriteCommandHandler()
        {

        }

        public async Task<Response<ReadFavoriteDto>> Handle(UpdateFavoriteCommand request, CancellationToken cancellationToken)
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
