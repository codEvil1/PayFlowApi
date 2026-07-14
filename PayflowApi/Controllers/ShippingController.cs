using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Shipping;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Data.Context;

namespace Payflow.Api.Controllers;

[ApiController]
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