using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Common.Constants;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Stores
{
    public class ReadStoreDto : IMapFrom<Store>
    {
        public string Guid { get; set; }
        public string Name { get; set; } = EmptyMessage.NotInformed;
        public string FullName { get; set; } = EmptyMessage.NotInformed;
        public string Cnpj { get; set; } = EmptyMessage.NotInformed;
    }
}
