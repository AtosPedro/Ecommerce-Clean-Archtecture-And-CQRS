using Ecommerce.Application.Common.Communication;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecommerce.Application.Common.Extensions
{
    public static class ErrorResponseExtension
    {
        public static void AddToModelState(this ErrorResponse result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.FieldName, error.Message);
            }
        }
    }
}
