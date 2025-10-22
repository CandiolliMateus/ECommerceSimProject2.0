using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;

namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities
{
    public class Customer : ICustomer
    {
        public DateTime RegisteredAt { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public bool IsLegalEntity { get; set; }
    }
}
