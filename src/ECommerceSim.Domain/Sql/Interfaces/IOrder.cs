namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface IOrder
    {
        int Id { get; set; }
        int CustomerId { get; set; }
        DateTime CreatedAt { get; set; }
        decimal TotalAmount { get; set; }
        string Status { get; set; }
    }
}
