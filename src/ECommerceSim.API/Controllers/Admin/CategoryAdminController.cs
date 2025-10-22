using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Commands;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimProject2.src.ECommerceSim.API.Controllers.Admin
{
    
    [ApiController]
    [Route("api/admin/[controller]")]
    public class CategoryAdminController : ControllerBase
    {
        private readonly ICategoryAdminService _service;

        public CategoryAdminController(ICategoryAdminService service) 
        {
            _service = service;
        }

        [HttpPost("createcategory")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryAdminCommand command)
        {
            var result = await _service.CreateCategoryAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("updatecategory{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] UpdateCategoryAdminCommand command)
        {
            command.Id = id;
            var result = await _service.UpdateCategoryAsync(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
