using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interfaces
{
    public interface ICashierRepository
    {
        Task AddAsync(Cashier cashier, CancellationToken cancellationToken);
        Task<PagedResult<Cashier>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<Cashier?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(Cashier cashier, CancellationToken cancellationToken);
        Task DeleteAsync(Cashier cashier, CancellationToken cancellationToken);
        Task<bool> ExistsByCpfAsync(string cpf, CancellationToken cancellationToken);
    }
}