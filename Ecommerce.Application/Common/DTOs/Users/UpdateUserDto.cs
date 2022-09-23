using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.Users
{
    public class UpdateUserDto : IMapFrom<User>
    {
        [Required]
        public string Guid { get; set; }
        [Required]
        public int StoreId { get; set; }

        [Required]
        public int OperationalUnitId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(5)]
        public string Role { get; set; }

    }
}
