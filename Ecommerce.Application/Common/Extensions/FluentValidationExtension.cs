using Ecommerce.Application.Common.Communication;
using FluentValidation.Results;

namespace Ecommerce.Application.Common.Extensions
{
    public static class FluentValidationExtension
    {
        public static ErrorResponse ToErrorResponse(this ValidationResult validationResult)
        {
            var errorResponse = new ErrorResponse();
            foreach (var error in validationResult.Errors)
            {
                var errorModel = new ErrorModel
                {
                    FieldName = error.PropertyName,
                    Message = error.ErrorMessage
                };
                errorResponse.Errors.Add(errorModel);
            }

            return errorResponse;
        }
    }
}
