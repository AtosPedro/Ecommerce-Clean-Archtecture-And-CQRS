using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class ProductTag : Entity
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int TagId { get; set; }

        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
