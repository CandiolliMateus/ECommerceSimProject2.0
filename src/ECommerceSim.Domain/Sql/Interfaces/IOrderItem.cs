namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface IOrderItem
    {
        int Id { get; set; }
        int OrderId { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
        decimal UnitPrice { get; set; }
    }
}
