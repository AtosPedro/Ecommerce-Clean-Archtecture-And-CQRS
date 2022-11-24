using Ecommerce.Application.Common.DTOs.Favorites;

namespace Ecommerce.Application.Favorites.Commands.CreateFavorite
{
    public record CreateFavoriteCommand
    {
        public CreateFavoriteDto Favorite { get; set; }
    }
}
