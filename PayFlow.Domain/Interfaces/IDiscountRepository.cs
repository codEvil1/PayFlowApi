using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interfaces
{
    public interface IDiscountRepository
    {
        Task AddAsync(Discount discount, CancellationToken cancellationToken);
        Task<PagedResult<Discount>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<Discount?> GetByCodeAsync(string code, CancellationToken cancellationToken);
        Task UpdateAsync(Discount discount, CancellationToken cancellationToken);
        Task DeleteAsync(Discount discount, CancellationToken cancellationToken);
        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken);
    }
}