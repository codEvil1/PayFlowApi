using PayFlow.Application.Features.Customer.Requests;
using PayFlow.Application.Features.Cashier.DTOs;

namespace PayFlow.Application.Interfaces
{
    public interface ICustomerService
    {
        Task CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CustomerDto?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken);
        Task UpdateAsync(string identifier, UpdateCustomerRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string identifier, CancellationToken cancellationToken);
    }
}