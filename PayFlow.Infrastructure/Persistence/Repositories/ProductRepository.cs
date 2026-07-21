using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Product
                .AsNoTracking()
                .ToListAsync(cancellationToken);
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