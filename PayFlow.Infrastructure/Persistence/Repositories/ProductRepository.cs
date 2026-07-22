using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Persistence.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await context.Product.AddAsync(product, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedResult<Product>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var query = context.Product.AsNoTracking();
            var totalCount = await query.CountAsync(cancellationToken);

            var product = await query
                .OrderBy(x => x.Id)
                .Skip(
                    (pagination.PageNumber - 1)
                    * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Product>(
                product,
                pagination.PageNumber,
                pagination.PageSize,
                totalCount
            );
        }

        public async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await context.Product
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            context.Product.Update(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            product.IsActive = false;

            context.Product.Update(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await context.Product
                .AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}