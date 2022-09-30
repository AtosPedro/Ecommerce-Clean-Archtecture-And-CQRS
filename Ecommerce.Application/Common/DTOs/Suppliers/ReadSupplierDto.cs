using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Suppliers
{
    public class ReadSupplierDto : IMapFrom<Supplier>
    {
        public string Guid { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
    }
}
