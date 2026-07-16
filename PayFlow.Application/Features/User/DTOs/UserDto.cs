using PayFlow.Domain.Enums;

namespace PayFlow.Application.Features.User.DTOs
{
    public class UserDto
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; init; }
        public bool IsActive { get; set; } = default;

    }
}
