using PayFlow.Infrastructure.Exceptions;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Features.Cashier.Requests;
using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.Infrastructure.Services
{
    public class CashierService(ICashierRepository repository) : ICashierService
    {
        public async Task CreateAsync(CreateCashierRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByCpfAsync(dto.Cpf, cancellationToken);

            if (exists)
                throw new BusinessException("Já existe um caixa cadastrado com este CPF.");

            var cashier = new Cashier
            {
                Cpf = dto.Cpf,
                Name = dto.Name,
                Email = dto.Email,
                Rating = dto.Rating,
            };

            await repository.AddAsync(cashier, cancellationToken);
        }

        public async Task<IEnumerable<CashierDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var cashiers = await repository.GetAllAsync(cancellationToken);

            return cashiers.Select(c => new CashierDto
            {
                Id = c.Id,
                Cpf = c.Cpf,
                Name = c.Name,
                Email = c.Email,
                Rating = c.Rating
            });
        }

        public async Task<CashierDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var cashier = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new BusinessException("Caixa não encontrado.");

            return new CashierDto
            {
                Id = cashier.Id,
                Cpf = cashier.Cpf,
                Name = cashier.Name,
                Email = cashier.Email,
                Rating = cashier.Rating
            };
        }
        public async Task UpdateAsync(int id, UpdateCashierRequest dto, CancellationToken cancellationToken)
        {
            var cashier = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new BusinessException("Caixa não encontrado.");

            cashier.Name = dto.Name;
            cashier.Email = dto.Email;
            cashier.Rating = dto.Rating;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var cashier = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new BusinessException("Caixa não encontrado.");

            await repository.DeleteAsync(cashier, cancellationToken);
        }
    }
}