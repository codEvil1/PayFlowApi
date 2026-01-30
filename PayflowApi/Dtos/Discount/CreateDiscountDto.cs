namespace PayflowApi.Dtos.Discount
{
    public class CreateDiscountDto
    {
        public string CouponCode { get; set; } = string.Empty;
        public int Percentage { get; set; }
    }
}
