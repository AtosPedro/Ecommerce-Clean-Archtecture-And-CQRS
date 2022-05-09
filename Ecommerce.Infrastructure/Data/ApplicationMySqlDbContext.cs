using Ecommerce.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApllicationDbContext
    {
    }
}
