using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
