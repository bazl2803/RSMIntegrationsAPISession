namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Application.DTOs.Auth;
    using Application.Exceptions;
    using Application.Interfaces;
    using Application.Services;
    using Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static User user = new();
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserDto request)
        {
            return Ok(_service.Register(request));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto request)
        {
            return Ok(_service.Login(request));
        }
    }
}
