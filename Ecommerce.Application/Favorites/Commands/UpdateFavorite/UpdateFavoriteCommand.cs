using Ecommerce.Application.Common.DTOs.Favorites;

namespace Ecommerce.Application.Favorites.Commands.UpdateFavorite
{
    public record UpdateFavoriteCommand
    {
        public UpdateFavoriteDto Favorite { get; set; }
    }
}
