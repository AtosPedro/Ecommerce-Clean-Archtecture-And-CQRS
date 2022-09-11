using Ecommerce.Application.Common.Communication;
using System.Runtime.Serialization;

namespace Ecommerce.Application.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ErrorResponse ErrorResponse { get; }
        public ValidationException(ErrorResponse errorResponse)
        {
            if (errorResponse == null)
                errorResponse = new ErrorResponse();

            ErrorResponse = errorResponse;
            ErrorResponse.BadRequest = true;
        }
    }
}
