using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.Users
{
    public sealed record AutenticatedUserDto: IMapFrom<User>
    {
        [MaxLength(80)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
