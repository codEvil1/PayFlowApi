using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Data.Context;

namespace PayFlow.Infrastructure.Data.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public async Task AddAsync(Customer customer)
        {
            await context.Customer.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task<Customer?> GetByIdentifierAsync(string identifier)
        {
            return await context.Customer
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Identifier == identifier);
        }
    }
}