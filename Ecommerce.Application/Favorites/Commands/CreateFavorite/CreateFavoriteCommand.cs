using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Favorites;

namespace Ecommerce.Application.Favorites.Commands.CreateFavorite
{
    public record CreateFavoriteCommand : BaseRequest, IRequestWrapper<ReadFavoriteDto>
    {
        public CreateFavoriteDto Favorite { get; set; }
    }

    public class CreateFavoriteCommandHandler : IHandlerWrapper<CreateFavoriteCommand, ReadFavoriteDto>
    {
        public CreateFavoriteCommandHandler()
        {

        }

        public async Task<Response<ReadFavoriteDto>> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
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
