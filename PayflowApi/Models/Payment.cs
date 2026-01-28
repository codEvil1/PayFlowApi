using PayFlowApi.Enum;
namespace PayFlowApi.Models
{
    public class Payment
    {
        public PaymentMethod Method { get; set; } = PaymentMethod.UNDEFINED;
        public int DeliveryTime { get; set; }
        public decimal Freight { get; set; }
    }
}
