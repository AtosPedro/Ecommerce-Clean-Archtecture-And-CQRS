using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class Material : Entity
    {
        public int SupplierId { get; set; }
        public string SupplierGuid { get; set; }

        [Required]
        public int StoreId { get; set; }
        public string StoreGuid { get; set; }

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

        public Supplier? Supplier { get; set; }
        public Store Store { get; set; }
    }
}
