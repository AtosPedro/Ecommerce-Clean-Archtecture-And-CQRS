namespace Ecommerce.Domain.Entities
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}
