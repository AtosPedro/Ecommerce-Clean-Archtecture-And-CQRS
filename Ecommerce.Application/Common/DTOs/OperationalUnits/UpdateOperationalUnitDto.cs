using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.OperationalUnits
{
    public class UpdateOperationalUnitDto : IMapFrom<OperationalUnit>
    {
        public string Guid { get; set; }
        public string StoreGuid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
