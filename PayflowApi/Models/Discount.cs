namespace PayFlowApi.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public int DiscountPercentage { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalWithDiscount { get; set; }
    }
}
