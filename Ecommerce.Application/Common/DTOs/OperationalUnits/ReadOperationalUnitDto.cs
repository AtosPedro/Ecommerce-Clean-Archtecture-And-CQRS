using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Common.Constants;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.OperationalUnits
{
    public class ReadOperationalUnitDto : IMapFrom<OperationalUnit>
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; } = EmptyMessage.NotInformed;
        public string Address { get; set; } = EmptyMessage.NotInformed;
    }
}
