using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Features.Cashier.DTOs;
using PayFlow.Infrastructure.Features.Customer.Requests;

namespace PayFlow.Application.Services
{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
    {
        public async Task<Customer> CreateAsync(CreateCustomerRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByIdentifierAsync(dto.Identifier, cancellationToken);

            if (exists)
                throw new ConflictException("Já existe um cliente cadastrado com este identificador.");

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

            return customer;
        }

        public async Task<PagedResponse<CustomerDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var customers = await repository.GetPagedAsync(pagination, cancellationToken);

            return new PagedResponse<CustomerDto>
            {
                Data = customers.Data
                    .Select(c => new CustomerDto
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
                    }),
                PageNumber = customers.PageNumber,
                PageSize = customers.PageSize,
                TotalCount = customers.TotalCount,
                TotalPages = customers.TotalPages,
            };
        }

        public async Task<CustomerDto?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new NotFoundException("Cliente não encontrado.");

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

        public async Task<Customer> UpdateAsync(string identifier, UpdateCustomerRequest dto, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new NotFoundException("Cliente não encontrado.");

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

            return customer;
        }

        public async Task DeleteAsync(string identifier, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new NotFoundException("Cliente não encontrado.");

            await repository.DeleteAsync(customer, cancellationToken);
        }
    }
}