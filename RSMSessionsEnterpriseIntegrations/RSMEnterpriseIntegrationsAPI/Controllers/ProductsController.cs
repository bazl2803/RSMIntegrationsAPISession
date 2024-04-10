namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Interfaces;
    using Application.DTOs.Product;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
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
            return Ok(await _service.GetProductById(id));
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            return Ok(await _service.CreateProduct(dto));
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            return Ok(await _service.UpdateProduct(dto));
        }

        [HttpDelete("Delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteProduct(id));
        }
    }
}
