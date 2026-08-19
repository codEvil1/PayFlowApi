using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Features.Auth.Requests;
using PayFlow.Application.Features.User.Requests;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Features.User.DTOs;
using PayFlow.Infrastructure.Features.User.Requests;
using PayFlow.Infrastructure.Interfaces;
using System.Security.Cryptography;

namespace PayFlow.Application.Services
{
    public class UserService(
        IUserRepository userRepository,
        IEmailRepository emailRepository,
        IEmailService emailService,
        IPasswordHasher passwordHasher) : IUserService
    {
        public async Task CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var emailExists = await userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (emailExists)
                throw new ConflictException("Já existe um usuário cadastrado com este e-mail.");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHasher.Hash(request.PasswordHash),
                EmailConfirmed = false,
                IsActive = true,
                LastLogin = DateTime.UtcNow
            };

            await userRepository.AddAsync(user, cancellationToken);

            await SendCodeAsync(new SendVerificationCodeRequest
            {
                Email = user.Email,
                Language = request.Language
            }, cancellationToken);
        }

        public async Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Usuário não encontrado.");

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task UpdateAsync(int id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Usuário não encontrado.");

            user.Name = request.Name;
            user.Email = request.Email;
            user.PasswordHash = passwordHasher.Hash(request.PasswordHash);

            await userRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Usuário não encontrado.");

            user.IsActive = false;

            await userRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task SendCodeAsync(SendVerificationCodeRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken)
                ?? throw new AppException("Usuário não encontrado.");

            if (user.EmailConfirmed)
                throw new AppException("E-mail já verificado.");

            var activeCodes = await emailRepository.GetAllActiveByUserIdAsync(user.Id, cancellationToken);
            foreach (var old in activeCodes)
                old.UsedAt = DateTime.UtcNow;

            var code = GenerateCode();

            var verification = new EmailVerification
            {
                UserId = user.Id,
                CodeHash = passwordHasher.Hash(code),
                ExpiresAt = DateTime.UtcNow.AddMinutes(10),
                CreatedAt = DateTime.UtcNow
            };

            await emailRepository.AddAsync(verification, cancellationToken);

            await emailService.SendVerificationCodeAsync(
                user.Email,
                user.Name,
                code,
                request.Language,
                cancellationToken);
        }

        private static string GenerateCode()
        {
            return RandomNumberGenerator
                .GetInt32(100000, 1000000)
                .ToString();
        }

        public async Task VerifyEmailAsync(VerifyEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken)
                 ?? throw new AppException("Usuário não encontrado.");

            if (user.EmailConfirmed)
                throw new AppException("E-mail já verificado.");

            var verification = await emailRepository
                .GetActiveByUserIdAsync(user.Id, cancellationToken)
                ?? throw new AppException("Código de verificação inválido.");

            if (verification.ExpiresAt < DateTime.UtcNow)
                throw new AppException("Código de verificação expirado.");

            if (!passwordHasher.Verify(request.Code, verification.CodeHash))
                throw new AppException("Código de verificação inválido.");

            user.EmailConfirmed = true;
            verification.UsedAt = DateTime.UtcNow;

            await userRepository.UpdateAsync(user, cancellationToken);
            await emailRepository.UpdateAsync(verification, cancellationToken);
        }
    }
}