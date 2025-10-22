using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Commands;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.DTOs;

namespace ECommerceSimProject2.src.ECommerceSim.Application.Admin.Interfaces
{
    public interface ICategoryAdminService
    {
        Task<CreateCategoryAdminDto> CreateCategoryAsync(CreateCategoryAdminCommand command);
        Task<UpdateCategoryAdminDto> UpdateCategoryAsync(UpdateCategoryAdminCommand command);
    }
}
