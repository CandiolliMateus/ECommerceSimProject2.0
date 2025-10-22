using ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.ValueObjects;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Interfaces
{
    public interface ICustomerHistory
    {
        string Id { get; set; }
        string CustomerId { get; set; }
        List<ViewedProduct> ViewedProducts { get; set; }
        DateTime LastInteraction { get; set; }
    }
}
