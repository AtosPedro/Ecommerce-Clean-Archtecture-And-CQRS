using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class ProductTag : Entity
    {
        [Required]
        public int ProductId { get; set; }
        public string ProductGuid { get; set; }
        [Required]
        public int TagId { get; set; }
        public string TagGuid { get; set; }
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
