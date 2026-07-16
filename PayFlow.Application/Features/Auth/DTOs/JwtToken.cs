namespace PayFlow.Application.Features.Auth.DTOs
{
    public class JwtToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; } = DateTime.MinValue;
    }
}