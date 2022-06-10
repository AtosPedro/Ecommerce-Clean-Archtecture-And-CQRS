using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Common.DTOs.Stores
{
    public class CreateStoreDto : IMapFrom<Store>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(18)]
        public string Cnpj { get; set; }
    }
}
