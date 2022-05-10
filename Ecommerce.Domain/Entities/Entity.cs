namespace Ecommerce.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UptatedAt { get; set; }
        public string? UptatedBy { get; set; }
    }
}
