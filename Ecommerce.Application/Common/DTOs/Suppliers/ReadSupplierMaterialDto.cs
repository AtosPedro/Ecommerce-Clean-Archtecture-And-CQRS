using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Suppliers
{
    public class ReadSupplierMaterialDto : IMapFrom<Material>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
    }
}
