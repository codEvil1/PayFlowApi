using PayFlow.Infrastructure.Features.Product.DTOs;
using PayFlow.Infrastructure.Features.Product.Requests;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Interfaces;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Common.Exceptions;

namespace PayFlow.Application.Services
{
    public class ProductService(IProductRepository repository, IStorageService storage) : IProductService
    {
        public async Task<Product> CreateAsync(CreateProductRequest dto, CancellationToken cancellationToken)
        {
            var exists = await repository.ExistsByIdAsync(dto.Id, cancellationToken);

            if (exists)
                throw new ConflictException("Já existe um produto cadastrado com este SKU.");

            string? imageUrl = null;

            if (dto.Image is not null)
                imageUrl = await storage.UploadAsync(dto.Image, "products");

            var product = new Product
            {
                Id = dto.Id,
                BarCode = dto.BarCode,
                Description = dto.Description,
                ImageUrl = imageUrl,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                IsActive = dto.IsActive
            };

            await repository.AddAsync(product, cancellationToken);

            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync(cancellationToken);

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                BarCode = p.BarCode,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            });
        }

        public async Task<ProductDto?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Produto não encontrado.");

            return new ProductDto
            {
                Id = product.Id,
                BarCode = product.BarCode,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };
        }

        public async Task<Product> UpdateAsync(string id, UpdateProductRequest dto, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(id, cancellationToken) 
                ?? throw new NotFoundException("Produto não encontrado.");

            var oldImageUrl = product.ImageUrl;

            var imageUrl = await storage.UploadAsync(dto.Image, "products");

            product.BarCode = dto.BarCode;
            product.Description = dto.Description;
            product.ImageUrl = imageUrl;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;

            await repository.UpdateAsync(product, cancellationToken);

            if (oldImageUrl is not null)
                await storage.DeleteAsync(oldImageUrl);

            return product;
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException("Produto não encontrado.");

            product.IsActive = false;

            await repository.UpdateAsync(product, cancellationToken);
        }
    }
}