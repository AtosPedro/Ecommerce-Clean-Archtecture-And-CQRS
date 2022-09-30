using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class Operation : Entity
    {
        [Required]
        public int MaterialId { get; set; }
        public string MaterialGuid { get; set; }
        
        [Required]
        public int StoreId { get; set; }
        public string StoreGuid { get; set; }
        
        [Required]
        public int OperationalUnitId { get; set; }
        public string OperationalUnitGuid { get; set; }

        [Required]
        [Column(TypeName = "decimal(13,2)")]
        public decimal Price { get; set; }
        
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public Material Material { get; set; }
        public OperationalUnit OperationalUnit { get; set; }
        public Store Store { get; set; }
    }
}
