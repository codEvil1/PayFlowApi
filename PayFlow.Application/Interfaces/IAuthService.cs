using Microsoft.AspNetCore.Identity.Data;
using PayFlow.Application.Features.Auth.DTOs;
using PayFlow.Application.Features.Auth.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthUserDto?> LoginAsync(AuthRequest request, CancellationToken cancellationToken);
        Task<AuthUserDto> RefreshTokenAsync(RefreshTokenRequest refreshToken, CancellationToken cancellationToken);
        Task RevokeTokenAsync(RefreshTokenRequest refreshToken, CancellationToken cancellationToken);
    }
}