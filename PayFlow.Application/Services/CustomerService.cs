using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Features.Address.DTOs;
using PayFlow.Application.Features.Customer.DTOs;
using PayFlow.Application.Features.Customer.Requests;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.Application.Services
{
    public class CustomerService(ICustomerRepository repository, IStorageService storage) : ICustomerService
    {
        public async Task<CustomerDto> CreateAsync(CreateCustomerRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByIdentifierAsync(dto.Identifier, cancellationToken);

            if (exists)
                throw new ConflictException("Já existe um cliente cadastrado com este identificador.");

            string? photoUrl = null;

            if (dto.Photo is not null)
                photoUrl = await storage.UploadAsync(dto.Photo, "customer");

            var customer = new Customer
            {
                Identifier = dto.Identifier,
                Name = dto.Name,
                Email = dto.Email,
                PhotoUrl = photoUrl,
                Phone = dto.Phone,
                Addresses = [.. dto.Addresses.Select(address => new Address
                {
                    Street = address.Street,
                    Number = address.Number,
                    Complement = address.Complement,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Uf = address.Uf,
                })]
            };

            await repository.AddAsync(customer, cancellationToken);

            return new CustomerDto
            {
                Identifier = customer.Identifier,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Addresses = customer.Addresses.Select(address => new AddressDto
                {
                    Street = address.Street,
                    Number = address.Number,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Uf = address.Uf,
                    Country = address.Country
                })
            };
        }

        public async Task<PagedResponse<CustomerDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var customers = await repository.GetPagedAsync(pagination, cancellationToken);

            return new PagedResponse<CustomerDto>
            {
                Data = customers.Data.Select(customer => new CustomerDto
                {
                    Identifier = customer.Identifier,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Addresses = customer.Addresses.Select(address => new AddressDto
                    {
                        Street = address.Street,
                        Number = address.Number,
                        City = address.City,
                        PostalCode = address.PostalCode,
                        Uf = address.Uf,
                        Country = address.Country
                    })
                }),
                PageNumber = customers.PageNumber,
                PageSize = customers.PageSize,
                TotalCount = customers.TotalCount,
                TotalPages = customers.TotalPages
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
                PhotoUrl = customer.PhotoUrl,
                Phone = customer.Phone,
                Addresses = customer.Addresses.Select(address => new AddressDto
                {
                    Street = address.Street,
                    Number = address.Number,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Uf = address.Uf,
                    Country = address.Country
                })
            };
        }

        public async Task<CustomerDto> UpdateAsync(string identifier, UpdateCustomerRequest dto, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new NotFoundException("Cliente não encontrado.");

            var oldPhotoUrl = customer.PhotoUrl;

            var photoUrl = await storage.UploadAsync(dto.Photo, "products");

            customer.Name = dto.Name;
            customer.PhotoUrl = photoUrl;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;

            foreach (var address in dto.Addresses)
            {
                customer.Addresses.Add(new Address
                {
                    Street = address.Street,
                    Number = address.Number,
                    Complement = address.Complement,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Uf = address.Uf
                });
            }

            await repository.UpdateAsync(customer, cancellationToken);

            if (oldPhotoUrl is not null)
                await storage.DeleteAsync(oldPhotoUrl);

            return new CustomerDto
            {
                Identifier = customer.Identifier,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Addresses = customer.Addresses.Select(address => new AddressDto
                {
                    Street = address.Street,
                    Number = address.Number,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Uf = address.Uf,
                    Country = address.Country
                })
            };
        }

        public async Task DeleteAsync(string identifier, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdentifierAsync(identifier, cancellationToken)
                ?? throw new NotFoundException("Cliente não encontrado.");

            await repository.DeleteAsync(customer, cancellationToken);
        }
    }
}