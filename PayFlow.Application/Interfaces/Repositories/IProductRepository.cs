using PayFlow.Domain.Entities;

namespace PayFlow.Infrastructure.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task<bool> ExistsByIdAsync(string sku, CancellationToken cancellationToken);
    }
}   