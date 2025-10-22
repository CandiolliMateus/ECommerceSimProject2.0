using ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.ValueObjects;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Documents
{
    public class CartDocument : ICartDocument
    {
        public string Id { get; set; } = string.Empty;
        public string CurtomerId { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new();
        public decimal Total { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
