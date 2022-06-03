using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class Operation : Entity
    {
        [Required]
        public int MaterialId { get; set; }
        
        [Required]
        public int StoreId { get; set; }
        
        [Required]
        public int OperationalUnitId { get; set; }

        [Required]
        [Column(TypeName = "decimal(13,2)")]
        public decimal Price { get; set; }
        
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}
