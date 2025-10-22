namespace ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Document { get; set; }
        bool IsLegalEntity { get; set; }
    }
}
