using PayFlow.Domain.Enums;

namespace PayFlow.Application.Features.Discount.Requests
{
    public class CreateDiscountRequest
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DiscountType Type { get; set; } = DiscountType.PERCENTAGE;
        public decimal Value { get; set; } = default;
        public DateOnly StartDate { get; set; } = new DateOnly();
        public DateOnly EndDate { get; set; } = new DateOnly();
        public decimal MinimumValue { get; set; } = default;
        public decimal MaximumDiscount { get; set; } = default;
        public bool IsActive { get; set; } = true;
    }
}
