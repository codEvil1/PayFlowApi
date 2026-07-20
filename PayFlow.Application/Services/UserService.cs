using Microsoft.AspNetCore.Identity;
using PayFlow.Application.Features.User.DTOs;
using PayFlow.Application.Features.User.Requests;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Application.Exceptions;

namespace PayFlow.Application.Services
{
    public class UserService(IUserRepository repository, IPasswordHasher passwordHasher) : IUserService
    {
        public async Task CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var emailExists = await repository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (emailExists)
                throw new BusinessException("Já existe um usuário cadastrado com este e-mail.");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHasher.Hash(request.PasswordHash)
            };

            await repository.AddAsync(user, cancellationToken);
        }

        public async Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new BusinessException("Usuário não encontrado.");

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task UpdateAsync(int id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new BusinessException("Usuário não encontrado.");

            user.Name = request.Name;
            user.Email = request.Email;
            user.PasswordHash = passwordHasher.Hash(request.PasswordHash);

            await repository.UpdateAsync(user, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new BusinessException("Usuário não encontrado.");

            user.IsActive = false;

            await repository.UpdateAsync(user, cancellationToken);
        }
    }
}