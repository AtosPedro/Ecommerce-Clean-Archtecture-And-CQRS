using Ecommerce.Application.Common.Mappings;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.DTOs.Users
{
    public class ReadUserDto : IMapFrom<User>
    {
        public string Guid { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
