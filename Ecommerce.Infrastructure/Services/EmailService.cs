using Ecommerce.Application.Common.Interfaces;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Ecommerce.Domain.ValueObjects;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;
using MailKit.Security;

namespace Ecommerce.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SendMail(Mail mail, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            message.To.Add(MailboxAddress.Parse(mail.To));
            message.Subject = mail.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = mail.Body
            };

            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    await smtpClient.ConnectAsync(
                        _configuration.GetSection("EmailHost").Value,
                        Convert.ToInt32(_configuration.GetSection("EmailPort").Value),
                        SecureSocketOptions.StartTls, 
                        cancellationToken);
                    await smtpClient.AuthenticateAsync(
                        _configuration.GetSection("EmailUserName").Value,
                        _configuration.GetSection("EmailPassword").Value);    
                    
                    return await smtpClient.SendAsync(message);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await smtpClient.DisconnectAsync(true, cancellationToken);
                }
            }
        }
    }
}
