using Ecommerce.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Order : Entity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required] 
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }

        public Product Product { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
    }
}
