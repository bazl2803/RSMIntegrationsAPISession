﻿namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Interfaces;
    using Application.DTOs.Departament;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
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
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            return Ok(await _service.GetDepartmentById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteDepartment(id));
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            return Ok(await _service.CreateDepartment(dto));
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateDepartmentDto dto)
        {
            return Ok(await _service.UpdateDepartment(dto));
        }
    }
}
