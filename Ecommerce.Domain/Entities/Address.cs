using Ecommerce.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Address : Entity
    {
        [Required]
        public int UserId { get; set; }
        public string UserGuid { get; set; }

        [Required]
        [MaxLength(40)]
        public string Street { get; set; }
        public int Number { get; set; }
        [Required]
        [MaxLength(8)]
        public string CEP { get; set; }
        [Required]
        [MaxLength(40)]
        public string Neighborhood { get; set; }
        [MaxLength(40)]
        public string Complement { get; set; }
        public UF UF { get; set; }
        public User User { get; set; }
    }
}
