namespace PayFlow.Domain.Entities;
public class Product
{
    public string Id { get; set; } = string.Empty;
    public string BarCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
    public int StockQuantity { get; set; } = int.MinValue;
    public bool IsActive { get; set; } = true;
}
