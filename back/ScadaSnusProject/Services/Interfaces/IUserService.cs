using ScadaSnusProject.DTOs;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.Services.Interfaces;

public interface IUserService
{
    public User RegisterNewUser(RegisterUserDTO registerUserDto);
    public User Login(LoginCredentialsDTO loginCredentialsDto);
}