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
        [HttpPost("add")]
        public async Task<IActionResult> AddCashier(CreateCashierDto dto)
        {
            var cashier = new Cashier
            {
                Cpf = dto.Cpf,
                Name = dto.Name,
                Email = dto.Email,
                Rating = dto.Rating
            };
                
            appDbcontext.Add(cashier);
            await appDbcontext.SaveChangesAsync();

            return Ok(cashier);
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
                Cpf = cashier.Cpf,
                Name = cashier.Name,
                Email = cashier.Email,
                IsActive = cashier.IsActive,
                Rating = cashier.Rating,
                CreatedAt = cashier.CreatedAt
            };

            return Ok(result);
        }
    }
}
