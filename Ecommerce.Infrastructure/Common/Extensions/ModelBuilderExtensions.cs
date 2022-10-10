using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Common.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void IgnoreGuids(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .Ignore(n => n.Guid);

            builder.Entity<Address>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.UserGuid);

            builder.Entity<Order>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.AddressGuid)
                .Ignore(n => n.ProductGuid)
                .Ignore(n => n.UserGuid);

            builder.Entity<Tag>()
                .Ignore(n => n.Guid);

            builder.Entity<Cart>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.UserGuid);

            builder.Entity<CartItem>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.ProductGuid)
                .Ignore(n => n.CartGuid);

            builder.Entity<Favorite>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.UserGuid)
                .Ignore(n => n.ProductGuid);

            builder.Entity<ProductPicture>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.ProductGuid);

            builder.Entity<ProductTag>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.TagGuid)
                .Ignore(n => n.ProductGuid);
            
            builder.Entity<Product>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.UserGuid);
        }
    }
}
