namespace Ecommerce.Application.Materials.DTOs
{
    public class CreateMaterialDto
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
    }
}
