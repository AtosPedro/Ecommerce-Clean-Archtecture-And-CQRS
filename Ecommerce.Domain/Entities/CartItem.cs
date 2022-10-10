using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class CartItem : Entity
    {
        [Required]
        public int CartId { get; set; }
        public string CartGuid { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductGuid { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
