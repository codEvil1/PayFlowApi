using PayFlow.Application.Features.Address;
using PayFlow.Domain.Interfaces;

namespace PayFlow.Application.Features.Customer
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task AddCustomerAsync(CustomerResponse dto)
        {
            var customer = new Domain.Entities.Customer
            {
                Identifier = dto.Identifier,
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = new Domain.Entities.Address
                {
                    Street = dto.Address.Street,
                    Number = dto.Address.Number,
                    City = dto.Address.City,
                    PostalCode = dto.Address.PostalCode,
                    State = dto.Address.State,
                    Uf = dto.Address.Uf,
                    Country = dto.Address.Country
                }
            };

            await customerRepository.AddAsync(customer);
        }

        public async Task<CustomerResponse?> GetByIdentifierAsync(string identifier)
        {
            var customer = await customerRepository.GetByIdentifierAsync(identifier);

            if (customer == null)
                return null;

            return new CustomerResponse
            {
                Identifier = customer.Identifier,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,
                Address = new AddressResponse
                {
                    Street = customer.Address.Street,
                    Number = customer.Address.Number,
                    City = customer.Address.City,
                    PostalCode = customer.Address.PostalCode,
                    State = customer.Address.State,
                    Uf = customer.Address.Uf,
                    Country = customer.Address.Country
                }
            };
        }
    }
}