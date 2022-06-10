using FluentValidation.Results;

namespace Ecommerce.Application.Common.Communication
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();       
    }
}
