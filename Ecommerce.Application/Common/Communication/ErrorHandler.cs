using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Common.Communication
{
    public static class ErrorHandler
    {
        public static ErrorResponse HandleApplicationError(Exception ex)
        {
            ErrorResponse errorResponse = null;

            if (ex is ValidationException)
            {
                var validationEx = ex as ValidationException;
                errorResponse = validationEx?.ErrorResponse ?? new ErrorResponse();

                if (validationEx?.ErrorResponse == null)
                {
                    var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                    errorResponse = new ErrorResponse { Errors = errors };
                    errorResponse.BadRequest = true;
                }
            }
            else if (ex is NotFoundException)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "Guid", Message = ex.Message } };
                errorResponse = new ErrorResponse { Errors = errors };
                errorResponse.NotFound = true;
            }
            else
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = $"Inner exception: {ex.InnerException}. Message: {ex.Message}" } };
                errorResponse = new ErrorResponse { Errors = errors };
                errorResponse.BadRequest = true;
            }

            return errorResponse;
        }
    }
}
