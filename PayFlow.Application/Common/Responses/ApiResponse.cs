using System.Diagnostics;

namespace PayFlow.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public IEnumerable<ApiError>? Errors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? TraceId {  get; set; }

        public static ApiResponse<T> SuccessResponse(T? data, string message = "Operação realizada com sucesso")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                TraceId = Activity.Current?.TraceId.ToString(),
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, IEnumerable<ApiError>? errors = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors,
                TraceId = Activity.Current?.TraceId.ToString()
            };
        }
    }
}