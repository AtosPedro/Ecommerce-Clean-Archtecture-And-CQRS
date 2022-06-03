using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class User : Entity
    {
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
        [MaxLength(5)]
        public string Role { get; set; }

        public Store Store { get; set; }
        public OperationalUnit OperationalUnit { get; set; }
    }
}
