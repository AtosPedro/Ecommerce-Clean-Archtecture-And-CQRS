using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.OperationalUnit
{
    public class CreateOperationalUnitDto
    {
        [Required]
        public int StoreId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Address { get; set; }
    }
}
