using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PayFlow.Api.Constants;
using PayFlow.Application.Security;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Features.Shipping;
using PayFlow.Infrastructure.Persistence.Context;

namespace Payflow.Api.Controllers;

[ApiController]
[Authorize(Roles = Roles.Admin)]
[Route("api/[controller]")]
public class ShippingController(AppDbContext appDbcontext) : ControllerBase
{
    [HttpPost]
    [EnableRateLimiting(RateLimitPolicies.Default)]
    public async Task<IActionResult> AddCashier(CreateShippingDto dto)
    {
        var shipping = new Shipping
        {
            Name = dto.Name,
            IsActive = dto.IsActive
        };

        appDbcontext.Add(shipping);
        await appDbcontext.SaveChangesAsync();

        return Ok();
    }
}