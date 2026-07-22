using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer, CancellationToken cancellationToken);
        Task<PagedResult<Customer>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<Customer?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
        Task DeleteAsync(Customer customer, CancellationToken cancellationToken);
        Task<bool> ExistsByIdentifierAsync(string identifier, CancellationToken cancellationToken);
    }
}