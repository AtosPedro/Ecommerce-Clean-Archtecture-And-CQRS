using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task<string> SendMail(Mail mail, CancellationToken cancellationToken);
    }
}
