using System.Diagnostics;

namespace PayFlow.Application.Common.Responses
{
    public sealed class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
        public T? Data { get; init; }
        public IEnumerable<ApiError>? Errors { get; init; }
        public DateTime Timestamp { get; init; } = DateTime.UtcNow;
        public string? TraceId { get; set; }

        public static ApiResponse<T> SuccessResponse(T? data, string message = "Operação realizada com sucesso")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                TraceId = Activity.Current?.TraceId.ToString()
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