using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;
using ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) 
        { 
        }

        public DbSet<DBTest> DBTest => Set<DBTest>();
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasKey(i => i.ProductId);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
