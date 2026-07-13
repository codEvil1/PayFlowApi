using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Product.Request;
using PayflowApi.Dtos.Product.Response;
using PayflowApi.Services.Storage;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(AppDbContext appDbcontext, IStorageService storage) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromForm] CreateProductRequest dto)
        {
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
            };

            appDbcontext.Product.Add(product);

            await appDbcontext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{sku}")]
        public async Task<IActionResult> GetProductByCode(string sku)
        {
            var product = await appDbcontext.Product.FindAsync(sku);

            if (product == null)
                return NotFound();

            var result = new ProductResponse
            {
                Id = product.Id,
                BarCode = product.BarCode,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive
            };

            return Ok(result);
        }
    }
}