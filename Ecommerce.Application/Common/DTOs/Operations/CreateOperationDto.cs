using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.Operations
{
    public class CreateOperationDto
    {
        public int MaterialId { get; set; }
        public int StoreId { get; set; }
        public int OperationalUnitId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
