using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.Address.Requests;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Data.Context;

namespace Payflow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(AppDbContext appDbcontext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAddress(CreateAddressRequest dto)
    {
        var address = new Address
        {
            Street = dto.Street,
            Number = dto.Number,
            City = dto.City,
            State = dto.State,
            Uf = dto.Uf,
            PostalCode = dto.PostalCode,
            Country = dto.Country
        };

        appDbcontext.Add(address);
        await appDbcontext.SaveChangesAsync();

        return Ok();
    }
}
