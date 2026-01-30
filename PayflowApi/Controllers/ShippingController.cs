using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Shipping;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
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
}