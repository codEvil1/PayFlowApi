using PayFlowApi.Enum;
namespace PayFlowApi.Models
{
    public class Payment
    {
        public PaymentMethod Method { get; set; } = PaymentMethod.UNDEFINED;
    }
}
