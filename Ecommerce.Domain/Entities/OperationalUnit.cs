using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class OperationalUnit : Entity
    {
        [Required]
        public int StoreId { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Address { get; set; }

        public Store Store { get; set; }
    }
}
