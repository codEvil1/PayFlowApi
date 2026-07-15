using PayFlow.Infrastructure.Exceptions;
using PayFlow.Infrastructure.Features.Address.DTOs;
using PayFlow.Infrastructure.Features.Customer.DTOs;
using PayFlow.Infrastructure.Features.Customer.Requests;
using PayFlow.Infrastructure.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;

namespace PayFlow.Infrastructure.Services
{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
    {
        public async Task CreateAsync(CreateCustomerRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByIdentifierAsync(dto.Identifier, cancellationToken);

            if (exists)
                throw new BusinessException("Já existe um cliente cadastrado com este identificador.");

            var customer = new Customer
            {
                Identifier = dto.Identifier,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = new Address
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

            await repository.AddAsync(customer, cancellationToken);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var customers = await repository.GetAllAsync(cancellationToken);

            return customers.Select(c => new CustomerDto
            {
                Identifier = c.Identifier,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = new AddressDto
                {
                    Street = c.Address.Street,
                    Number = c.Address.Number,
                    City = c.Address.City,
                    PostalCode = c.Address.PostalCode,
                    State = c.Address.State,
                    Uf = c.Address.Uf,
                    Country = c.Address.Country
                }
            });
        }

        public async Task<CustomerDto?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new BusinessException("Cliente não encontrado.");

            return new CustomerDto
            {
                Identifier = customer.Identifier,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = new AddressDto
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

        public async Task UpdateAsync(string identifier, UpdateCustomerRequest dto, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new BusinessException("Cliente não encontrado.");

            customer.Name = dto.Name;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address.Street = dto.Address.Street;
            customer.Address.Number = dto.Address.Number;
            customer.Address.City = dto.Address.City;
            customer.Address.PostalCode = dto.Address.PostalCode;
            customer.Address.State = dto.Address.State;
            customer.Address.Uf = dto.Address.Uf;
            customer.Address.Country = dto.Address.Country;

            await repository.UpdateAsync(customer, cancellationToken);
        }

        public async Task DeleteAsync(string identifier, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new BusinessException("Cliente não encontrado.");

            await repository.DeleteAsync(customer, cancellationToken);
        }
    }
}