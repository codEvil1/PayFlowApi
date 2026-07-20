using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Application.Persistence.Context;

namespace PayFlow.Application.Persistence.Repositories
{
    public class DiscountRepository(AppDbContext context) : IDiscountRepository
    {
        public async Task AddAsync(Discount discount, CancellationToken cancellationToken)
        {
            await context.Discount.AddAsync(discount, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Discount>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Discount
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Discount?> GetByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return await context.Discount
                .FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
        }

        public async Task UpdateAsync(Discount discount, CancellationToken cancellationToken)
        {
            context.Discount.Update(discount);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Discount discount, CancellationToken cancellationToken)
        {
            discount.IsActive = false;

            context.Discount.Update(discount);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return await context.Discount
                .AnyAsync(x => x.Code == code, cancellationToken);
        }
    }
}