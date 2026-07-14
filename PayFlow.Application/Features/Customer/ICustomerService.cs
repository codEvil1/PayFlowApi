namespace PayFlow.Application.Features.Customer;

public interface ICustomerService
{
    Task AddCustomerAsync(CustomerResponse dto);
    Task<CustomerResponse?> GetByIdentifierAsync(string identifier);
}