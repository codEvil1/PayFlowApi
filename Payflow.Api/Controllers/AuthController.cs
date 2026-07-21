using Microsoft.AspNetCore.Mvc;
using PayFlow.Infrastructure.Features.Auth.Requests;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService service) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest request, CancellationToken cancellationToken)
        {
            var result = await service.LoginAsync(request, cancellationToken);

            return Ok(result);
        }


        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await service.RefreshTokenAsync(request, cancellationToken);

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            await service.RevokeTokenAsync(request, cancellationToken);

            return NoContent();
        }
    }
}