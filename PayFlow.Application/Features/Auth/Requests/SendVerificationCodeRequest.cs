namespace PayFlow.Application.Features.Auth.Requests
{
    public sealed class SendVerificationCodeRequest
    {
        public required string Email { get; init; }
        public string Language { get; init; } = "pt-BR";
    }
}