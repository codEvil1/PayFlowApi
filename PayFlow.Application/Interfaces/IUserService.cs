using PayFlow.Application.Features.Auth.Requests;
using PayFlow.Application.Features.User.Requests;
using PayFlow.Infrastructure.Features.User.DTOs;
using PayFlow.Infrastructure.Features.User.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
        Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(int id, UpdateUserRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task VerifyEmailAsync(VerifyEmailRequest request, CancellationToken cancellationToken);
        Task SendCodeAsync(SendVerificationCodeRequest request, CancellationToken cancellationToken);
    }
}