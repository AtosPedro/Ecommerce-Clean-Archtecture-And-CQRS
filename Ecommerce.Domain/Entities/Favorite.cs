using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Favorite : Entity
    {
        [Required]
        public int ProductId { get; set; }
        public string ProductGuid { get; set; }
        [Required]
        public int UserId { get; set; }
        public string UserGuid { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
