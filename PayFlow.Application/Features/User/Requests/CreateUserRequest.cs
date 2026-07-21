using Swashbuckle.AspNetCore.Annotations;

namespace PayFlow.Infrastructure.Features.User.Requests
{
    public class CreateUserRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [SwaggerSchema(Format = "password")]
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
