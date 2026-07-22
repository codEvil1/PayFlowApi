using Microsoft.AspNetCore.Mvc.RazorPages;
using PayFlow.Application.Common.Exceptions;
using PayFlow.Application.Common.Responses;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Features.Discount.DTOs;
using PayFlow.Infrastructure.Features.Discount.Requests;

namespace PayFlow.Application.Services
{
    public class DiscountService(IDiscountRepository repository) : IDiscountService
    {
        public async Task<Discount> CreateAsync(CreateDiscountRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByCodeAsync(dto.Code, cancellationToken);

            if (exists)
                throw new ConflictException("Já existe um desconto cadastrado com este código.");

            var discount = new Discount
            {
                Code = dto.Code,
                Description = dto.Description,
                Type = dto.Type,
                Value = dto.Value,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                MinimumValue = dto.MinimumValue,
                MaximumDiscount = dto.MaximumDiscount,
            };

            await repository.AddAsync(discount, cancellationToken);

            return discount;
        }

        public async Task<PagedResponse<DiscountDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var discounts = await repository.GetPagedAsync(pagination, cancellationToken);

            return new PagedResponse<DiscountDto>
            {
                Data = discounts.Data
                    .Select(d => new DiscountDto
                    {
                        Code = d.Code,
                        Description = d.Description,
                        Type = d.Type,
                        Value = d.Value,
                        StartDate = d.StartDate,
                        EndDate = d.EndDate,
                        MinimumValue = d.MinimumValue,
                        MaximumDiscount = d.MaximumDiscount
                    }),
                PageNumber = discounts.PageNumber,
                PageSize = discounts.PageSize,
                TotalCount = discounts.TotalCount,
                TotalPages = discounts.TotalPages,
            };
        }

        public async Task<DiscountDto?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var discount = await repository.GetByCodeAsync(id, cancellationToken)
                ?? throw new NotFoundException("Desconto não encontrado.");

            return new DiscountDto
            {
                Code = discount.Code,
                Description = discount.Description,
                Type = discount.Type,
                Value = discount.Value,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                MinimumValue = discount.MinimumValue,
                MaximumDiscount = discount.MaximumDiscount
            };
        }

        public async Task<Discount> UpdateAsync(string id, UpdateDiscountRequest dto, CancellationToken cancellationToken)
        {
            var discount = await repository.GetByCodeAsync(id, cancellationToken)
                ?? throw new NotFoundException("Desconto não encontrado.");

            discount.Description = dto.Description;
            discount.Type = dto.Type;
            discount.Value = dto.Value;
            discount.StartDate = dto.StartDate;
            discount.EndDate = dto.EndDate;
            discount.MinimumValue = dto.MinimumValue;
            discount.MaximumDiscount = dto.MaximumDiscount;

            await repository.UpdateAsync(discount, cancellationToken);

            return discount;
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var discount = await repository.GetByCodeAsync(id, cancellationToken)
                ?? throw new NotFoundException("Desconto não encontrado.");

            await repository.DeleteAsync(discount, cancellationToken);
        }
    }
}