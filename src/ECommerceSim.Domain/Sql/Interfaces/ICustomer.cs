namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface ICustomer : IPerson
    {
        DateTime RegisteredAt { get; set; }
    }
}
