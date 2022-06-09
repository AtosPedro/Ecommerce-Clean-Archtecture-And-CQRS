namespace Ecommerce.Application.Common.Communication
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, object ex, T data = default) => new Response<T>(data, message, true, ex);
        public static Response<T> Ok<T>(T data, string message) => new Response<T>(data, message, false, null);
    }

    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
        public object Exception { get; set; }

        public Response(T data, string msg, bool error, object exception)
        {
            Data = data;
            Message = msg;
            Error = error;
            Exception = exception;
        }
    }
}
