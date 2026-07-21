namespace PayFlow.Application.Common.Exceptions
{
    public sealed class ExternalServiceException(string message) : ApplicationException(message) { }
}