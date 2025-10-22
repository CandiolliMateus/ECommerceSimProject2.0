namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface IInventory
    {
        int ProductId { get; set; }
        int QuantityAvailable { get; set; }
        DateTime LastUpdate { get; set; }
    }
}
