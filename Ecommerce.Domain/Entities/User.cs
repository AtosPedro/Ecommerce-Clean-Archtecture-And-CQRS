using Ecommerce.Domain.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class User : Entity
    {
        [Required]
        [MaxLength(80)]
        public string Email { get; set; }        
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
        [Required]
        [MaxLength(5)]
        public UserRole Role { get; set; }
        public byte[] ProfileImage { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<Favorite> Favorites { get; set; }

    }
}
