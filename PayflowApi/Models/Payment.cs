using PayFlowApi.Enum;
namespace PayFlowApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentMethod Method { get; set; } = PaymentMethod.UNDEFINED;
    }
}
