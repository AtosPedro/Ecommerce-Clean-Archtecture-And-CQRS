using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        
        [MaxLength(50)]
        [Column(TypeName="varchar(50)")]
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UptatedAt { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? UptatedBy { get; set; }
    }
}
