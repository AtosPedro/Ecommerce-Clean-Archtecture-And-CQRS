namespace Ecommerce.Application.Common.Communication
{
    public abstract record BaseRequest
    {
        public int UserId { get; set; }
        public int UserEmail { get; set; }
        public int UserName { get; set; }
    }
}
