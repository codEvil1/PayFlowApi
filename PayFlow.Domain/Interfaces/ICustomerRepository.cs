using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task<Customer?> GetByIdentifierAsync(string identifier);
}