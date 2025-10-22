using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;
using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence;
using ECommerceSimProject2.src.ECommerceSim.Shared.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly OracleDbContext _context;

        public CategoryRepository(OracleDbContext context) 
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            var normalizedName = TextNormalizer.Normalize(name);
            var allNames = await _context.Categories.Select(c => c.Name).ToListAsync();
            return allNames.Any(c => TextNormalizer.Normalize(c) == normalizedName);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
