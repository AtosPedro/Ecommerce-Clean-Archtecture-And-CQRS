using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.OperationalUnits
{
    public class CreateOperationalUnitDto : IMapFrom<OperationalUnit>
    {
        public string StoreGuid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
