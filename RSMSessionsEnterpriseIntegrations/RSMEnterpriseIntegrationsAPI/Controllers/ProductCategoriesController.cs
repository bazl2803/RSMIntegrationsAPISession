
namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Application.DTOs.ProductCategory;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoriesController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            return Ok(await _service.GetProductCategoryById(id));
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(string name)
        {
            return Ok(await _service.CreateProductCategory(name));
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateProductCategoryDto dto)
        {
            return Ok(await _service.UpdateProductCategory(dto));
        }

        [HttpDelete("Delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteProductCategory(id));
        }
    }
}
