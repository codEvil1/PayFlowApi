using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Persistence.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
    {
        public async Task AddAsync(RefreshToken refreshToken)
        {
            await context.RefreshTokens.AddAsync(refreshToken);

            await context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            context.RefreshTokens.Update(refreshToken);

            await context.SaveChangesAsync();
        }
    }
}