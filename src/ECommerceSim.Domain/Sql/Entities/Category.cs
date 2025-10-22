using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities
{
    public class Category : ICategory
    {
        public Category(string name) 
        { 
            Name = name;
        }

        public Category() { }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
