using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Infrastructure.Features.Cashier.Requests;

namespace PayFlow.Infrastructure.Interfaces
{
    public interface ICashierService
    {
        Task CreateAsync(CreateCashierRequest request, CancellationToken cancellationToken);
        Task<IEnumerable<CashierDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CashierDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(int id, UpdateCashierRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}