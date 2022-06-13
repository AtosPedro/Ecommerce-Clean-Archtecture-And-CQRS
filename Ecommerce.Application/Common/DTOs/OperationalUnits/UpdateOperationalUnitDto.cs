using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.OperationalUnits
{
    public class UpdateOperationalUnitDto : IMapFrom<OperationalUnit>
    {
        [Required]
        public int StoreId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Address { get; set; }
    }
}
