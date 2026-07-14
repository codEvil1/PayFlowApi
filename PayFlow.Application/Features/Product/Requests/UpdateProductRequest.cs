using Microsoft.AspNetCore.Http;

namespace PayFlow.Application.Features.Product.Requests
{
    public class UpdateProductRequest
    {
        public string BarCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;
        public decimal Price { get; set; } = decimal.Zero;
        public int StockQuantity { get; set; } = int.MinValue;
    }
}