namespace Ecommerce.Domain.Entities
{
    public class Material : Entity
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
    }
}
