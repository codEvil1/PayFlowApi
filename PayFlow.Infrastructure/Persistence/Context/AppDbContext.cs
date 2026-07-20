using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;

namespace PayFlow.Application.Persistence.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
