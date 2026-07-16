using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Auth.Requests;
using PayFlow.Application.Interfaces;

namespace PayFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthRequest request, CancellationToken cancellationToken)
        {
            var result = await service.LoginAsync(request, cancellationToken);

            return Ok(result);
        }
    }
}