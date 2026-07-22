using PayFlow.Application.Common.Responses;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Infrastructure.Features.Cashier.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface ICashierService
    {
        Task<Cashier> CreateAsync(CreateCashierRequest request, CancellationToken cancellationToken);
        Task<PagedResponse<CashierDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<CashierDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Cashier> UpdateAsync(int id, UpdateCashierRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}