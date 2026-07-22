using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Infrastructure.Features.Cashier.Requests;

namespace PayFlow.Application.Services
{
    public class CashierService(ICashierRepository repository) : ICashierService
    {
        public async Task<Cashier> CreateAsync(CreateCashierRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByCpfAsync(dto.Cpf, cancellationToken);

            if (exists)
                throw new ConflictException("Já existe um caixa cadastrado com este CPF.");

            var cashier = new Cashier
            {
                Cpf = dto.Cpf,
                Name = dto.Name,
                Email = dto.Email,
                Rating = dto.Rating,
            };

            await repository.AddAsync(cashier, cancellationToken);

            return cashier;
        }

        public async Task<PagedResponse<CashierDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var cashiers = await repository.GetPagedAsync(pagination, cancellationToken);

            return new PagedResponse<CashierDto>
            {
                Data = cashiers.Data
                    .Select(c => new CashierDto
                    {
                        Id = c.Id,
                        Cpf = c.Cpf,
                        Name = c.Name,
                        Email = c.Email,
                        Rating = c.Rating
                    }),
                PageNumber = cashiers.PageNumber,
                PageSize = cashiers.PageSize,
                TotalCount = cashiers.TotalCount,
                TotalPages = cashiers.TotalPages,
            };
        }

        public async Task<CashierDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var cashier = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Caixa não encontrado.");

            return new CashierDto
            {
                Id = cashier.Id,
                Cpf = cashier.Cpf,
                Name = cashier.Name,
                Email = cashier.Email,
                Rating = cashier.Rating
            };
        }
        public async Task<Cashier> UpdateAsync(int id, UpdateCashierRequest dto, CancellationToken cancellationToken)
        {
            var cashier = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Caixa não encontrado.");

            cashier.Name = dto.Name;
            cashier.Email = dto.Email;
            cashier.Rating = dto.Rating;

            await repository.UpdateAsync(cashier, cancellationToken);

            return cashier;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var cashier = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Caixa não encontrado.");

            await repository.DeleteAsync(cashier, cancellationToken);
        }
    }
}