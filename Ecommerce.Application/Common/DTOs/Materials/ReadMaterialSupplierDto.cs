using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Materials
{
    public class ReadMaterialSupplierDto : IMapFrom<Supplier>
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
    }
}
