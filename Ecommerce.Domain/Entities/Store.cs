using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Store : Entity
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        [Required]
        [MaxLength(18)]
        public string Cnpj { get; set; }

        public List<Material> Materials { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
