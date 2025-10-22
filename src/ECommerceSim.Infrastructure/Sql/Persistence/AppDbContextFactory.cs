using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=ECommerceSimProject2;Trusted_Connection=True;Encrypt=False;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
