using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities
{
    public class Inventory : IInventory
    {
        public int ProductId { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
