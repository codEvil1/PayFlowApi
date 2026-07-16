using PayFlow.Application.Features.Auth.DTOs;
using PayFlow.Application.Features.Auth.Requests;
using PayFlow.Application.Features.User.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Exceptions;

namespace PayFlow.Application.Services
{
    public class AuthService(IUserRepository repository, IPasswordHasher passwordHasher, IJwtService jwtService) : IAuthService
    {
        public async Task<AuthResponse?> LoginAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByEmailAsync(request.Email, cancellationToken)
                ?? throw new BusinessException("Credenciais inválidas.");

            if (!passwordHasher.Verify(request.Password, user.PasswordHash))
                throw new BusinessException("Credenciais inválidas.");

            var jwt = jwtService.GenerateToken(user);

            return new AuthResponse
            {
                AccessToken = jwt.Token,
                ExpiresAt = jwt.ExpiresAt,
                User = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Role = user.Role
                }
            };
        }
    }
}
