using PayFlow.Infrastructure.Features.Address.DTOs;

namespace PayFlow.Infrastructure.Features.Cashier.DTOs
{
    public class UserDto
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;
    }
}
