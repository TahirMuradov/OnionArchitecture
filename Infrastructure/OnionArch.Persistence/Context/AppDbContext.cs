
using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Context
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
     public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
