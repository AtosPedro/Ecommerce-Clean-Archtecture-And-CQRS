using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.Stores
{
    public class UpdateStoreDto : IMapFrom<Store>
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Cnpj { get; set; }
    }
}
