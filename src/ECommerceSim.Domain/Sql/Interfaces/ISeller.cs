namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface ISeller : IPerson
    {
        string? TradeName { get; set; }
    }
}
