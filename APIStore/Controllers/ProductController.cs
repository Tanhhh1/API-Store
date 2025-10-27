using APIStore.DTOs.Categories;
using APIStore.DTOs.Products;
using APIStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllProduct();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _service.GetProductById(id);
            if (dto is null) return NotFound(new { message = "Không tìm thấy sản phẩm" });
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductSaveDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var created = await _service.CreateProduct(dto);
                return Ok(new { message = "Thêm sản phẩm thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductSaveDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var updated = await _service.UpdateProduct(id, dto);
                if (!updated)
                    return NotFound(new { message = "Không tìm thấy sản phẩm" });

                return Ok(new { message = "Cập nhật sản phẩm thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return Ok(new { message = "Cập nhật sản phẩm thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteProduct(id);
            if (!deleted) return NotFound(new { message = "Không tìm thấy sản phẩm" });
            return Ok(new { message = "Xóa sản phẩm thành công" });
        }
    }
}
