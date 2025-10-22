using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence
{
    public class OracleDbContextFactory : IDesignTimeDbContextFactory<OracleDbContext>
    {
        public OracleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OracleDbContext>();
            optionsBuilder.UseOracle("User Id=System;Password=admin;Data Source=localhost:1521/xe");
            return new OracleDbContext(optionsBuilder.Options);
        }
    }
}
