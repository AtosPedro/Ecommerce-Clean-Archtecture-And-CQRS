using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public User User { get; set; }
    }
}
