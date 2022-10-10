using Ecommerce.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Order : Entity
    {
        [Required]
        public int UserId { get; set; }
        public string UserGuid { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductGuid { get; set; }
        [Required]
        public int AddressId { get; set; }
        public string AddressGuid { get; set; }
        [Required] 
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public decimal DeliveryPrice { get; set; }
        public Address DeliveryAddress { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
