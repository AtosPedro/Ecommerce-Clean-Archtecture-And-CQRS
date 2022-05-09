namespace Ecommerce.Domain.Entities
{
    public class Supplier : Entity
    {
        public int Name { get; set; }
        public int Cnpj { get; set; }
        public int Cpf { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}
