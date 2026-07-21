using PayFlow.Infrastructure.Features.Auth.DTOs;
using PayFlow.Domain.Entities;

namespace PayFlow.Infrastructure.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateToken(User user);
    }
}