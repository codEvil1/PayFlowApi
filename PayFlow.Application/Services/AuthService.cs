using PayFlow.Application.Features.Auth.DTOs;
using PayFlow.Application.Features.Auth.Requests;
using PayFlow.Application.Features.User.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Application.Exceptions;

namespace PayFlow.Application.Services
{
    public class AuthService(
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IRefreshTokenService refreshTokenService) : IAuthService
    {
        public async Task<AuthUserDto?> LoginAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken)
                ?? throw new BusinessException("Credenciais inválidas.");

            if (!passwordHasher.Verify(request.Password, user.PasswordHash))
                throw new BusinessException("Credenciais inválidas.");

            var jwt = jwtService.GenerateToken(user);

            var refreshToken = new RefreshToken
            {
                Token = refreshTokenService.Generate(),
                UserId = user.Id,
                Expiration = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow
            };

            await refreshTokenRepository.AddAsync(refreshToken);

            return new AuthUserDto
            {
                AccessToken = jwt.Token,
                RefreshToken = refreshToken.Token,
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

        public async Task<AuthUserDto> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await refreshTokenRepository.GetByTokenAsync(request.RefreshToken) 
                ?? throw new BusinessException("Refresh token expirado.");

            var user = refreshToken.User;
            var jwt = jwtService.GenerateToken(user);

            refreshToken.Token = refreshTokenService.Generate();
            refreshToken.Expiration = DateTime.UtcNow.AddDays(7);
            refreshToken.CreatedAt = DateTime.UtcNow;

            await refreshTokenRepository.UpdateAsync(refreshToken);

            return new AuthUserDto
            {
                AccessToken = jwt.Token,
                RefreshToken = refreshToken.Token,
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

        public async Task RevokeTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await refreshTokenRepository.GetByTokenAsync(request.RefreshToken)
                ?? throw new BusinessException("Refresh token inválido.");

            refreshToken.Revoked = true;

            await refreshTokenRepository.UpdateAsync(refreshToken);
        }
    }
}