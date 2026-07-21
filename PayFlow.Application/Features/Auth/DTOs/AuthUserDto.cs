using PayFlow.Infrastructure.Features.User.DTOs;

namespace PayFlow.Infrastructure.Features.Auth.DTOs
{
    public sealed class AuthUserDto
    {
        public string AccessToken { get; init; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; init; }
        public UserDto User { get; init; } = default!;
    }
}