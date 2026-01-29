using Microsoft.EntityFrameworkCore;
using PayFlowApi.Models;

namespace PayFlowApi.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Address> Adress { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
    }
}
