using ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.ValueObjects;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Interfaces
{
    public interface ICartDocument
    {
        string Id { get; set; }
        string CurtomerId { get; set; }
        List<CartItem> Items { get; set; }
        decimal Total { get; set; }
        DateTime UpdateAt { get; set; }
    }
}
