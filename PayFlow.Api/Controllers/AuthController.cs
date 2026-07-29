using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Api.Extensions;
using PayFlow.Application.Interfaces;
using PayFlow.Infrastructure.Features.Auth.Requests;
using System.Security.Claims;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService service, IWebHostEnvironment env) : ControllerBase
    {

        [HttpPost("login")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> Login(AuthRequest request, CancellationToken cancellationToken)
        {
            var result = await service.LoginAsync(request, cancellationToken);

            Response.SetAuthCookies(result, env);

            return Ok(result);
        }


        [HttpPost("refresh")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = Request.GetRefreshToken();

            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized();

            var result = await service.RefreshTokenAsync(
                new RefreshTokenRequest { RefreshToken = refreshToken },
                cancellationToken);

            Response.SetAuthCookies(result, env);

            return Ok(result);
        }

        [HttpPost("logout")]
        [EnableRateLimiting(RateLimitPolicies.Auth)]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            var refreshToken = Request.GetRefreshToken();

            if (!string.IsNullOrEmpty(refreshToken))
            {
                await service.RevokeTokenAsync(
                    new RefreshTokenRequest { RefreshToken = refreshToken },
                    cancellationToken);
            }

            Response.ClearAuthCookies();

            return Ok();
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var userId = User.FindFirst("sub")?.Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var name = User.FindFirst("name")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new { id = userId, name, email, role });
        }
    }
}