namespace Ecommerce.Domain.Entities
{
    public class Log : Entity
    {
        public string Type { get; set; }

        public string Message { get; set; }
    }
}
