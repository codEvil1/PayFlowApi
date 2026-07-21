using System.Security.Cryptography;
using PayFlow.Infrastructure.Interfaces;

namespace PayFlow.Infrastructure.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        public string Generate()
        {
            var randomBytes = new byte[64];

            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }
    }
}