namespace ECommerceSimProject2.src.ECommerceSim.Application.Admin.DTOs
{
    public class CreateCategoryAdminDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
    }
}
