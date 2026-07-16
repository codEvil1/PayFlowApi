using PayFlow.Application.Features.Auth.DTOs;
using PayFlow.Domain.Entities;

namespace PayFlow.Application.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateToken(User user);
    }
}