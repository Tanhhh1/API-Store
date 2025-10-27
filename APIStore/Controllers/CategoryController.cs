using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIStore.Services.Interfaces;
using APIStore.DTOs.Categories;

namespace APIStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllCategory();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _service.GetCategoryById(id);
            if (dto is null) return NotFound(new { message = "Không tìm thấy danh mục" });
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategorySaveDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateCategory(dto);
            return Ok(new {message = "Thêm danh mục thành công"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategorySaveDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _service.UpdateCategory(id, dto);
            if (!updated) return NotFound(new { message = "Không tìm thấy danh mục" });
            return Ok(new { message = "Cập nhật danh mục thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCategory(id);
            if (!deleted) return NotFound(new { message = "Không tìm thấy danh mục" });
            return Ok(new { message = "Xóa danh mục thành công" });
        }
    }
}