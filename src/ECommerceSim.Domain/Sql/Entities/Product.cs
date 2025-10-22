using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
