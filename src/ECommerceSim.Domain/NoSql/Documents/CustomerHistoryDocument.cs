using ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.ValueObjects;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Documents
{
    public class CustomerHistoryDocument : ICustomerHistory
    {
        public string Id { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public List<ViewedProduct> ViewedProducts { get; set; } = new();
        public DateTime LastInteraction { get; set; }
    }
}
