using PayFlow.Application.Common.Responses;
using PayFlow.Application.Features.Product.DTOs;
using PayFlow.Domain.Common.Models;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Features.Product.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken);
        Task<PagedResponse<ProductDto>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
        Task<ProductDto?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(string id, UpdateProductRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}