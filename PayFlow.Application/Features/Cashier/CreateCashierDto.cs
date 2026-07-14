namespace PayFlow.Application.Features.Cashier;

public class CreateCashierDto
{
    public string Cpf { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public double Rating { get; set; } = default;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
