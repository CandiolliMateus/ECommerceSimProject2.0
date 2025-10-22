namespace ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Interfaces
{
    public interface ICustomerHistoryRepository
    {
        Task<ICustomerHistory?> GetCustomerIdAsync(string customerId);
        Task SaveAsync(ICustomerHistory history);
    }
}
