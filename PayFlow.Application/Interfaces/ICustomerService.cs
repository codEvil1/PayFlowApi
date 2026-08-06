using PayFlow.Application.Common.Responses;
using PayFlow.Application.Features.Customer.DTOs;
using PayFlow.Application.Features.Customer.Requests;
using PayFlow.Domain.Common.Models;

namespace PayFlow.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken);
        Task<PagedResponse<CustomerDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<CustomerDto?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken);
        Task<CustomerDto> UpdateAsync(string identifier, UpdateCustomerRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string identifier, CancellationToken cancellationToken);
    }
}