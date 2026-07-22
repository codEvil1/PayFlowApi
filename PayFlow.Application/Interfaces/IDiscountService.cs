using PayFlow.Application.Common.Responses;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Features.Discount.DTOs;
using PayFlow.Infrastructure.Features.Discount.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount> CreateAsync(CreateDiscountRequest request, CancellationToken cancellationToken);
        Task<PagedResponse<DiscountDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<DiscountDto?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<Discount> UpdateAsync(string id, UpdateDiscountRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}