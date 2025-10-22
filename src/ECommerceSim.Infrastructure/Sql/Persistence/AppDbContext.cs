using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // public DbSet<DBTest> DBTest => Set<DBTest>();
        public DbSet<DBTestTwo> DBTestTwo => Set<DBTestTwo>();
    }
}
