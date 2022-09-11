namespace Ecommerce.Application.Common.Communication
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public bool BadRequest { get; set; }
        public bool NotFound { get; set; }
    }
}
