using PayFlow.Application.Features.User.DTOs;

namespace PayFlow.Application.Features.Auth.DTOs
{
    public sealed class AuthResponse
    {
        public string AccessToken { get; init; } = string.Empty;
        public DateTime ExpiresAt { get; init; }
        public UserDto User { get; init; } = default!;
    }
}