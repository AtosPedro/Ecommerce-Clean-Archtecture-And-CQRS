using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Materials
{
    public class CreateMaterialDto : IMapFrom<Material>
    {
        public int SupplierId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
