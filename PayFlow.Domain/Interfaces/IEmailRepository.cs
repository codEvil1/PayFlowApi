using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interfaces
{
    public interface IEmailRepository
    {
        Task<EmailVerification?> GetActiveByUserIdAsync(int userId, CancellationToken cancellationToken);
        Task AddAsync(EmailVerification verification, CancellationToken cancellationToken);
        Task UpdateAsync(EmailVerification verification, CancellationToken cancellationToken);
        Task<List<EmailVerification>> GetAllActiveByUserIdAsync(int userId, CancellationToken cancellationToken);
    }
}