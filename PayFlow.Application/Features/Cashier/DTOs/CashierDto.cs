namespace PayFlow.Application.Features.Cashier.DTOs
{
    public class CashierDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Rating { get; set; } = default;
        public bool IsActive { get; set; } = default;
    }
}
