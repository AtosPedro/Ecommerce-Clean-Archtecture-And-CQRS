using Ecommerce.Domain.Common.Constants;

namespace Ecommerce.Application.Common.DTOs.OperationalUnit
{
    public class ReadOperationalUnitDto
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = EmptyMessage.NotInformed;
        public string Address { get; set; } = EmptyMessage.NotInformed;
    }
}
