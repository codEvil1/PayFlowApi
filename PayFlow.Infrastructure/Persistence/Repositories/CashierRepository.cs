using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Data.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class CashierRepository(AppDbContext context) : ICashierRepository
    {
        public async Task AddAsync(Cashier cashier, CancellationToken cancellationToken)
        {
            await context.Cashier.AddAsync(cashier, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Cashier>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Cashier
                .AsNoTracking()
                .ToListAsync(cancellationToken);
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