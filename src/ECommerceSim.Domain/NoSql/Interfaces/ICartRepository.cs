namespace ECommerceSimProject2.src.ECommerceSim.Domain.NoSql.Interfaces
{
    public interface ICartRepository
    {
        Task<ICartDocument?> GetByCustomerIdAsync(string customerId);
        Task SaveAsync(ICartDocument cart);
        Task DeleteAsynx(string cartId);
    }
}
