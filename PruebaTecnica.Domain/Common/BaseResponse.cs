namespace Domain.Common.Response
{
    /// <summary>
    /// Este metodo permite representar una respeusta Estandar para todos los servicios
    /// </summary>
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success => StatusCode is >= 200 and < 300;


        public BaseResponse(T data, int statusCode = 200, string message = "")
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }

        public static BaseResponse<T> Ok(T data, string message = "") =>
            new(data, 200, message);


        public static BaseResponse<T> BadRequest(string message) =>
            new(default!, 400, message);

    }
}
