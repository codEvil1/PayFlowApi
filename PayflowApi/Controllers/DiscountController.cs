using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Discount;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Data.Context;

namespace Payflow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountController(AppDbContext appDbcontext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCashier(CreateDiscountDto dto)
    {
        var discount = new Discount
        {
            CouponCode = dto.CouponCode,
            Percentage = dto.Percentage
        };

        appDbcontext.Add(discount);
        await appDbcontext.SaveChangesAsync();

        return Ok();
    }
}
