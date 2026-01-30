using Microsoft.AspNetCore.Mvc;
using PayflowApi.Dtos.Adress;
using PayFlowApi.Data;
using PayFlowApi.Models;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController(AppDbContext appDbcontext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAddress(CreateAddressDto dto)
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
}
