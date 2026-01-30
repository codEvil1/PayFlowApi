using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Customer;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(AppDbContext appDbcontext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCashier(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Identifier = dto.Identifier,
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                AddressId = dto.AddressId,
            };

            appDbcontext.Add(customer);
            await appDbcontext.SaveChangesAsync();

            return Ok();
        }
    }
}