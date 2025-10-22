using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Commands;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.DTOs;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Handlers;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;
using ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence;

namespace ECommerceSimProject2.src.ECommerceSim.API.Services.Admin
{
    public class CategoryAdminService : ICategoryAdminService
    {
        private readonly OracleDbContext _context;
        private readonly CreateCategoryAdminHandler _createCategoryHandler;
        private readonly UpdateCategoryAdminHandler _updateCategoryAdminHandler;

        public CategoryAdminService(OracleDbContext context, 
            CreateCategoryAdminHandler createCategoryHandler,
            UpdateCategoryAdminHandler updateCategoryAdminHandler) 
        { 
            _context = context;
            _createCategoryHandler = createCategoryHandler;
            _updateCategoryAdminHandler = updateCategoryAdminHandler;
        }

        public async Task InsertCategoryAsync(int id, string name)
        {
            var category = new Category { Id = id, Name = name };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<CreateCategoryAdminDto> CreateCategoryAsync(CreateCategoryAdminCommand command)
        {
            return await _createCategoryHandler.CreateCategoryAsync(command);
        }

        public async Task<UpdateCategoryAdminDto> UpdateCategoryAsync(UpdateCategoryAdminCommand command)
        {
            return await _updateCategoryAdminHandler.UpdateCategoryAsync(command);
        }
    }
}
