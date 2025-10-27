using APIStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllCustomer();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _service.GetCustomerById(id);
            if (dto is null) return NotFound(new { message = "Không tìm thấy người dùng" });
            return Ok(dto);
        }
    }
}
