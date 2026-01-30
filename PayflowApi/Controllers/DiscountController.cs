using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Discount;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
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
}
