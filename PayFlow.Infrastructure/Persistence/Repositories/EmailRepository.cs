using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Persistence.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class EmailRepository(AppDbContext context) : IEmailRepository
    {
        public async Task<EmailVerification?> GetActiveByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await context.EmailVerifications
                .Where(x =>
                    x.UserId == userId &&
                    x.UsedAt == null &&
                    x.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(EmailVerification verification, CancellationToken cancellationToken)
        {
            await context.EmailVerifications.AddAsync(verification, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
        }


        public async Task UpdateAsync(EmailVerification verification, CancellationToken cancellationToken)
        {
            context.EmailVerifications.Update(verification);

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<EmailVerification>> GetAllActiveByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await context.EmailVerifications
                .Where(x =>
                    x.UserId == userId &&
                    x.UsedAt == null &&
                    x.ExpiresAt > DateTime.UtcNow)
                .ToListAsync(cancellationToken);
        }
    }
}