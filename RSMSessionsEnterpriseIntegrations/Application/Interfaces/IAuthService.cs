using Application.DTOs.Auth;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        User Register(UserDto dto);
        string Login(UserDto dto);
    }
}
