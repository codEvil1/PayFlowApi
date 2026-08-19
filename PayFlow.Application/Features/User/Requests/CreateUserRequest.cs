using Swashbuckle.AspNetCore.Annotations;

namespace PayFlow.Application.Features.User.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [SwaggerSchema(Format = "password")]
        public string PasswordHash { get; set; } = string.Empty;
        public string Language { get; set; } = "pt-BR";
        public bool IsActive { get; set; } = true;
    }
}
