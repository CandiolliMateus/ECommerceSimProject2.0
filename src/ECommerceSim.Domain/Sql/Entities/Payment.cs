using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities
{
    public class Payment : IPayment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime PadeAt { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
    }
}
