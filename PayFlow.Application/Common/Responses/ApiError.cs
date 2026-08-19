namespace PayFlow.Application.Common.Responses
{
    public class ApiError
    {
        public string Code { get; init; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}