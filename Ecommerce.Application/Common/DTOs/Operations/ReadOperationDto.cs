using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Operations
{
    public class ReadOperationDto : IMapFrom<Operation>
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int StoreId { get; set; }
        public int OperationalUnitId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
