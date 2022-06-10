using FluentValidation.Results;

namespace Ecommerce.Application.Common.Communication
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public static ErrorResponse ToErrorResponse(ValidationResult validationResult)
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
