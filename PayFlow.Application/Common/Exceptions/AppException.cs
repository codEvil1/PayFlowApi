namespace PayFlow.Application.Common.Exceptions
{
    public sealed class AppException(string message) : ApplicationException(message) { }
}