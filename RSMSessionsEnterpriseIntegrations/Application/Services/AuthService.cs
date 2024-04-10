using Application.DTOs.Auth;
using Application.Exceptions;
using Application.Interfaces;
using Application.Validators;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private static User user = new();
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Register(UserDto dto)
        {
            if (dto is null
                || string.IsNullOrWhiteSpace(dto.Email)
                || string.IsNullOrWhiteSpace(dto.Password))
            {
                throw new BadRequestException("User or password can't be empty");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            return user;
        }

        public string Login(UserDto dto)
        {
            if (user.Email != dto.Email || BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                throw new BadRequestException("User or password wrong");
            }

            return CreateToken(dto);
        }

        public string CreateToken(UserDto dto)
        {
            var validator = new UserDtoValidator();
            var validationResult = validator.Validate(dto);

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:JWTSecret").Value!);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, dto.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
