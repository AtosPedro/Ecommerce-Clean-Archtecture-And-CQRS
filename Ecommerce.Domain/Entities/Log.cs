namespace Ecommerce.Domain.Entities
{
    public class Log 
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public Guid? ResponseId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
