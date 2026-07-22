using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task<PagedResult<Product>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(Product product, CancellationToken cancellationToken);
        Task<bool> ExistsByIdAsync(string id, CancellationToken cancellationToken);
    }
}