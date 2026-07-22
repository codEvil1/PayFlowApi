using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Persistence.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class DiscountRepository(AppDbContext context) : IDiscountRepository
    {
        public async Task AddAsync(Discount discount, CancellationToken cancellationToken)
        {
            await context.Discount.AddAsync(discount, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedResult<Discount>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var query = context.Discount.AsNoTracking();
            var totalCount = await query.CountAsync(cancellationToken);

            var discount = await query
                .OrderBy(x => x.Id)
                .Skip(
                    (pagination.PageNumber - 1)
                    * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Discount>(
                discount,
                pagination.PageNumber,
                pagination.PageSize,
                totalCount
            );
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