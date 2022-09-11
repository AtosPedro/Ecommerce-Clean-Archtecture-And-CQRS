using Ecommerce.Application.Common.Communication;

namespace Ecommerce.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public ErrorResponse ErrorResponse { get; }
        public NotFoundException(string message = "Entity not found") : base (message)
        {
            ErrorResponse = new ErrorResponse();
            ErrorResponse.NotFound = true;
        }
    }
}
