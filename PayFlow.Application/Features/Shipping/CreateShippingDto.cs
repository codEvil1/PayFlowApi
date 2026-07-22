namespace PayFlow.Infrastructure.Features.Shipping;

public class CreateShippingDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
