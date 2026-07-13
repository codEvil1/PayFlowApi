using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Customer.Response;
using PayFlowApi.Data;
using PayFlowApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(AppDbContext appDbcontext) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer(CustomerResponse dto)
        {
            var customer = new Customer
            {
                Identifier = dto.Identifier,
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = dto.Address
            };

            appDbcontext.Add(customer);
            await appDbcontext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetCustomerByIdentifier(string identifier)
        {
            var customer = await appDbcontext.Customer
                .FirstOrDefaultAsync(customer => customer.Identifier == identifier);

            if (customer == null)
                return NotFound();

            var result = new CustomerResponse
            {
                Identifier = customer.Identifier,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,
                Address = customer.Address
            };

            return Ok(result);
        }
    }
}