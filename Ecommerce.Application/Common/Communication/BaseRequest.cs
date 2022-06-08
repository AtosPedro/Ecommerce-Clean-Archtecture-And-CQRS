namespace Ecommerce.Application.Common.Communication
{
    public abstract record BaseRequest
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
    }
}
