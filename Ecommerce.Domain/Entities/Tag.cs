using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Tag : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
