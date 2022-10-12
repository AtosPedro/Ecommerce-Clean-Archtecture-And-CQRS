using Ecommerce.Domain.Common.Enums;

namespace Ecommerce.Domain.ValueObjects
{
    public class Mail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
