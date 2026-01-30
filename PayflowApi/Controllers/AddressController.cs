using Microsoft.AspNetCore.Mvc;
using PayFlowApi.Data;

namespace PayflowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController(AppDbContext appDbcontext) : ControllerBase
    {

    }
}
