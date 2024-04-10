
namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Application.DTOs.SalesOrderHeader;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderHeadersController : ControllerBase
    {
        private readonly ISalesOrderHeaderService _service;

        public SalesOrderHeadersController(ISalesOrderHeaderService service)
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
            return Ok(await _service.GetSalesOrderHeaderById(id));
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(CreateSalesOrderHeaderDto dto)
        {
            return Ok(await _service.CreateSalesOrderHeader(dto));
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateSalesOrderHeaderDto dto)
        {
            return Ok(await _service.UpdateSalesOrderHeader(dto));
        }

        [HttpDelete("Delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteSalesOrderHeader(id));
        }
    }
}
