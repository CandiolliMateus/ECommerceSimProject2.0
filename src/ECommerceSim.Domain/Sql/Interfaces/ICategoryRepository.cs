using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> ExistsByNameAsync(string name);

        Task<Category> GetByIdAsync(int id);
        Task UpdateAsync(Category category);
    }
}
