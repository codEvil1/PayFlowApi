using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Persistence.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class CashierRepository(AppDbContext context) : ICashierRepository
    {
        public async Task AddAsync(Cashier cashier, CancellationToken cancellationToken)
        {
            await context.Cashier.AddAsync(cashier, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedResult<Cashier>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var query = context.Cashier.AsNoTracking();
            var totalCount = await query.CountAsync(cancellationToken);

            var cashier = await query
                .OrderBy(x => x.Name)
                .Skip(
                    (pagination.PageNumber - 1)
                    * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Cashier>(
                cashier,
                pagination.PageNumber,
                pagination.PageSize,
                totalCount
            );
        }

        public async Task<Cashier?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Cashier
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Cashier cashier, CancellationToken cancellationToken)
        {
            context.Cashier.Update(cashier);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Cashier cashier, CancellationToken cancellationToken)
        {
            cashier.IsActive = false;

            context.Cashier.Update(cashier);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByCpfAsync(string cpf, CancellationToken cancellationToken)
        {
            return await context.Cashier
                .AnyAsync(x => x.Cpf == cpf, cancellationToken);
        }
    }
}