using PayFlow.Application.Common.Responses;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Infrastructure.Features.Customer.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken);
        Task<PagedResponse<CustomerDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<CustomerDto?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken);
        Task<Customer> UpdateAsync(string identifier, UpdateCustomerRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string identifier, CancellationToken cancellationToken);
    }
}