namespace Ecommerce.Application.Orders.Queries
{
    public record GetOrderByIdQuery
    {
        public int Guid { get; set; }
    }
}
