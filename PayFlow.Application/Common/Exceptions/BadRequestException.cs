namespace PayFlow.Application.Common.Exceptions
{
    public sealed class BadRequestException(string message) : ApplicationException(message) { }
}