using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Features.User;
using PayFlow.Domain.Entities;
using PayFlow.Infrastructure.Data.Context;

namespace Payflow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(AppDbContext appDbcontext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAddress(CreateUserDto dto)
    {
        var user = new User
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = dto.PasswordHash,
            IsActive = dto.IsActive,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        appDbcontext.Add(user);
        await appDbcontext.SaveChangesAsync();

        return Ok();
    }
}
