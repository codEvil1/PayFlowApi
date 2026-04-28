using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Cashier;
using PayflowApi.Dtos.Customer;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCashierById(int id)
        {
            var cashier = await appDbcontext.Cashier.FindAsync(id);

            if (cashier == null)
                return NotFound();

            var result = new CashierDto
            {
                Id = cashier.Id,
                Name = cashier.Name,
                Rating = cashier.Rating
            };

            return Ok(result);
        }
    }
}
