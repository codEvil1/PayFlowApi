namespace PayFlow.Application.Common.Exceptions
{
    public sealed class UnauthorizedException(string message) : ApplicationException(message) { }
}