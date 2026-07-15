using PayFlow.Infrastructure.Features.Product.DTOs;
using PayFlow.Infrastructure.Features.Product.Requests;

namespace PayFlow.Application.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductRequest request, CancellationToken cancellationToken);
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductDto?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task UpdateAsync(string id, UpdateProductRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}