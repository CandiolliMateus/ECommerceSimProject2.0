using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Commands;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.DTOs;
using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Entities;
using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;

namespace ECommerceSimProject2.src.ECommerceSim.Application.Admin.Handlers
{
    public class CreateCategoryAdminHandler
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryAdminHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCategoryAdminDto> CreateCategoryAsync(CreateCategoryAdminCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                return new CreateCategoryAdminDto
                {
                    Success = false,
                    Message = "o nome da categoria é obrigatório."
                };
            }

            var existsByName = await _repository.ExistsByNameAsync(command.Name);
            if (existsByName)
            {
                return new CreateCategoryAdminDto
                {
                    Success = false,
                    Message = $"A categoria {command.Name} já existe."
                };
            }

            var category = new Category(command.Name);
            var createCategory = await _repository.CreateCategoryAsync(category);
            
            return new CreateCategoryAdminDto
            {
                Id = createCategory.Id,
                Name = createCategory.Name,
                Success = true,
                Message = "Categoria criada com sucesso."
            };
        }
    }
}
