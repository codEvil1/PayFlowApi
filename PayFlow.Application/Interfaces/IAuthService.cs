using PayFlow.Application.Features.Auth.DTOs;
using PayFlow.Application.Features.Auth.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(AuthRequest request, CancellationToken cancellationToken);
    }
}