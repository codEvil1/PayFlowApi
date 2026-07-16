using PayFlow.Infrastructure.Features.Discount.DTOs;
using PayFlow.Infrastructure.Features.Discount.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IDiscountService
    {
        Task CreateAsync(CreateDiscountRequest request, CancellationToken cancellationToken);
        Task<IEnumerable<DiscountDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<DiscountDto?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task UpdateAsync(string id, UpdateDiscountRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}