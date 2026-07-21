using Microsoft.AspNetCore.Http;

namespace PayFlow.Infrastructure.Features.Product.Requests
{
    public class CreateProductRequest
    {
        public string Id { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;
        public decimal Price { get; set; } = decimal.Zero;
        public int StockQuantity { get; set; } = int.MinValue;
        public bool IsActive { get; set; } = true;
    }
}
