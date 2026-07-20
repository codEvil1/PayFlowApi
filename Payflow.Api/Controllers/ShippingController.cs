using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Domain.Entities;
using PayFlow.Application.Features.Shipping;
using PayFlow.Application.Persistence.Context;

namespace Payflow.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ShippingController(AppDbContext appDbcontext) : ControllerBase
{
    [HttpPost]
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