using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Cart : Entity
    {
        [Required]
        public int UserId { get; set; }
        public string UserGuid { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
