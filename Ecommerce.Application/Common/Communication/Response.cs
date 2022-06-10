namespace Ecommerce.Application.Common.Communication
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, ErrorResponse error) => new Response<T>(message, true, error);
        public static Response<T> Ok<T>(T data, string message) => new Response<T>(data, message, false, null);
    }

    public class Response<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
        public ErrorResponse ErrorResponse { get; set; }

        public Response(T data, string msg, bool error, ErrorResponse errorResponse)
        {
            Data = data;
            Message = msg;
            Error = error;
            ErrorResponse = errorResponse;
        }

        public Response(string msg, bool error, ErrorResponse errorResponse)
        {
            Message = msg;
            Error = error;
            ErrorResponse = errorResponse;
        }
    }
}
