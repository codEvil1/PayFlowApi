using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Customer;

namespace Payflow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddCustomer(CustomerResponse dto)
    {
        await customerService.AddCustomerAsync(dto);

        return Ok();
    }

    [HttpGet("{identifier}")]
    public async Task<IActionResult> GetCustomerByIdentifier(string identifier)
    {
        var customer = await customerService.GetByIdentifierAsync(identifier);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
}