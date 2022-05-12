using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs
{
    public class ReadMaterialDto : IMapFrom<Material>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ReadMaterialSupplierDto Supplier { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UptatedAt { get; set; }
        public string? UptatedBy { get; set; }
    }
}
