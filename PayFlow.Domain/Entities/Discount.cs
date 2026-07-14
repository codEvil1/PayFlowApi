namespace PayFlow.Domain.Entities;
public class Discount
{
    public int Id { get; set; }
    public string CouponCode { get; set; } = string.Empty;
    public int Percentage { get; set; }
}
