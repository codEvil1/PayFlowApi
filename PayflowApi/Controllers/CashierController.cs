using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Cashier;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashierController(AppDbContext appDbcontext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCashier(CreateCashierDto dto)
        {
            var cashier = new Cashier
            {
                Name = dto.Name,
                Rating = dto.Rating
            };

            appDbcontext.Add(cashier);
            await appDbcontext.SaveChangesAsync();

            return Ok();
        }
    }
}
