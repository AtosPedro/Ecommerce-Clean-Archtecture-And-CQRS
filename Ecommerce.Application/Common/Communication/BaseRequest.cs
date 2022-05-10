namespace Ecommerce.Application.Common.Communication
{
    public abstract record BaseRequest
    {
        public int UserId { get; set; }
    }
}
