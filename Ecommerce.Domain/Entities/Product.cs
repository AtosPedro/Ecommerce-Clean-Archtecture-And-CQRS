using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class Product : Entity
    {
        [Required]
        public int UserId { get; set; }
        public string UserGuid { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(13,2)")]
        public decimal Price { get; set; }

        public List<ProductPicture> Pictures { get; set; }
        public List<ProductTag> Tags { get; set; }
    }
}
