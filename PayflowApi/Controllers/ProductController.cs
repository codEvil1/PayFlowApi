using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Product;
using PayflowApi.Models.Response;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(AppDbContext appDbcontext) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromForm] CreateProductDto dto)
        {
            byte[]? imageBytes = null;

            if (dto.Image is not null)
            {
                using var memoryStream = new MemoryStream();

                await dto.Image.CopyToAsync(memoryStream);

                imageBytes = memoryStream.ToArray();
            }

            var product = new Product
            {
                Id = dto.Id,
                BarCode = dto.BarCode,
                Description = dto.Description,
                Image = imageBytes,
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

            var result = new ProductResponseDto
            {
                Id = product.Id,
                BarCode = product.BarCode,
                Description = product.Description,
                Image = product.Image is null
                    ? null
                    : $"data:image/png;base64,{Convert.ToBase64String(product.Image)}",
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive
            };

            return Ok(result);
        }
    }
}