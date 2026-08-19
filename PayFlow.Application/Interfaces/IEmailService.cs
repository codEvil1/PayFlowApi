namespace PayFlow.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationCodeAsync(string email, string name, string code, string language, CancellationToken cancellationToken);
        Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken);
    }
}