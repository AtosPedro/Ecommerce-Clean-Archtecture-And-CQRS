using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.Operations
{
    public class CreateOperationDto
    {
        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public int OperationalUnitId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
