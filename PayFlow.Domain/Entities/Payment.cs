using PayFlow.Domain.Enums;

namespace PayFlow.Domain.Entities;
public class Payment
{
    public int Id { get; set; }
    public PaymentMethod Method { get; set; } = PaymentMethod.UNDEFINED;
}
