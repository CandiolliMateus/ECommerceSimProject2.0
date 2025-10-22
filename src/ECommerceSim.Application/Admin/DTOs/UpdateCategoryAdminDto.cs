namespace ECommerceSimProject2.src.ECommerceSim.Application.Admin.DTOs
{
    public class UpdateCategoryAdminDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
