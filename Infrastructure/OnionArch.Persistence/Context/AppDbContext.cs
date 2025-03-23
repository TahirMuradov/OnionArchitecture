
using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Entities.Common;

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
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added||e.State==EntityState.Modified).ToList().ForEach(e =>
            {
                if (e.State == EntityState.Added)
                    e.Property("CreatedDate").CurrentValue = DateTime.Now;
                else if(e.State==EntityState.Modified)
                    e.Property("ModifiedDate").CurrentValue = DateTime.Now;
       
            });
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
