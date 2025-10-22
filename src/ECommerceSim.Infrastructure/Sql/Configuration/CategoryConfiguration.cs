using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORIES");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID").ValueGeneratedNever();
            builder.Property(t => t.Name).HasColumnName("NAME").IsRequired();
        }
    }
}
