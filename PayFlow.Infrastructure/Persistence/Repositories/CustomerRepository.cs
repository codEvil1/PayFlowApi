using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Persistence.Context;

namespace PayFlow.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            await context.Customer.AddAsync(customer, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Customer
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Customer?> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken)
        {
            return await context.Customer
                .FirstOrDefaultAsync(x => x.Identifier == identifier, cancellationToken);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            context.Customer.Update(customer);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Customer customer, CancellationToken cancellationToken)
        {
            customer.IsActive = false;

            context.Customer.Update(customer);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByIdentifierAsync(string identifier, CancellationToken cancellationToken)
        {
            return await context.Customer
                .AnyAsync(x => x.Identifier.Equals(identifier), cancellationToken);
        }
    }
}