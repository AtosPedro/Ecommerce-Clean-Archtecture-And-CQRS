using Ecommerce.Application.Common.Communication;
using System.Runtime.Serialization;

namespace Ecommerce.Application.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; }
        public ValidationException(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }
    }
}
