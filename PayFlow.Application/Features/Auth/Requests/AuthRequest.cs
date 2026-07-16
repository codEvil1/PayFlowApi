using Swashbuckle.AspNetCore.Annotations;

namespace PayFlow.Application.Features.Auth.Requests
{
    public class AuthRequest
    {
        public string Email { get; set; } = string.Empty;

        [SwaggerSchema(Format = "password")]
        public string Password { get; set; } = string.Empty;
    }
}
