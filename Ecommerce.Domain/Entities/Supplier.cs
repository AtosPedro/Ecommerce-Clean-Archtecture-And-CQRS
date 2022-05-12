using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Supplier : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [MaxLength(18)]
        public string? Cnpj { get; set; }
        
        [MaxLength(11)]
        public string? Cpf { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public IEnumerable<Material> Materials { get; set; }
    }
}
