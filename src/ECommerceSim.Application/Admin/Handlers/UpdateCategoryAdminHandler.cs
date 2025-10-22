using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Commands;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.DTOs;
using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Shared.Utilities;

namespace ECommerceSimProject2.src.ECommerceSim.Application.Admin.Handlers
{
    public class UpdateCategoryAdminHandler
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryAdminHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCategoryAdminDto> UpdateCategoryAsync(UpdateCategoryAdminCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                return new UpdateCategoryAdminDto
                {
                    Success = false,
                    Message = "O nome da categoria é obrigatório."
                };
            }

            var category = await _repository.GetByIdAsync(command.Id);
            if (category == null)
            {
                return new UpdateCategoryAdminDto
                {
                    Success = false,
                    Message = "Categoria não encontrada."
                };
            }

            var normalizedNewName = TextNormalizer.Normalize(command.Name);
            var normalizedCurrentName = TextNormalizer.Normalize(category.Name);
            var nameExists = await _repository.ExistsByNameAsync(command.Name);
            if (nameExists && normalizedNewName != normalizedCurrentName)
            {
                return new UpdateCategoryAdminDto
                {
                    Success = false,
                    Message = $"Já existe uma categoria com o nome: {command.Name}."
                };
            }

            category.Name = command.Name;
            await _repository.UpdateAsync(category);
            return new UpdateCategoryAdminDto
            {
                Id = category.Id,
                Name = category.Name,
                Success = true,
                Message = "Categoria atualizada com sucesso."
            };
        }
    }
}
