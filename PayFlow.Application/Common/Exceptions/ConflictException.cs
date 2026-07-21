namespace PayFlow.Application.Common.Exceptions
{
    public sealed class ConflictException(string message) : ApplicationException(message) { }
}