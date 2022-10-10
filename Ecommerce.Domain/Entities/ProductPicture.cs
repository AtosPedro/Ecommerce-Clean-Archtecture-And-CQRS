using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class ProductPicture : Entity
    {
        [Required]
        public int ProductId { get; set; }
        public int ProductGuid { get; set; }
        [Required]
        public byte[] Image { get; set; }

        public Product Product { get; set; }
    }
}
