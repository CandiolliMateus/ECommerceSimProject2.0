namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface IPayment
    {
        int Id { get; set; }
        int OrderId { get; set; }
        string Method { get; set; }
        decimal Amount { get; set; }
        DateTime PadeAt { get; set; }
        string TransactionCode { get; set; }
    }
}
