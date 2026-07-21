using PayFlow.Infrastructure.Features.Customer.Requests;
using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Domain.Entities;

namespace PayFlow.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CustomerDto?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken);
        Task<Customer> UpdateAsync(string identifier, UpdateCustomerRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string identifier, CancellationToken cancellationToken);
    }
}