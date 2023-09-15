using ScadaSnusProject.DTOs;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User RegisterNewUser(RegisterUserDTO registerUserDto)
    {
        var user = _userRepository.GetUserByUsername(registerUserDto.Username);
        if (user != null)
        {
            throw new Exception("User with exact username already exists!");
        }
        var newUser = new User(registerUserDto.Name, registerUserDto.Surname, registerUserDto.Username, registerUserDto.Password);
        _userRepository.AddUser(newUser);
        return newUser;
    }

    public User Login(LoginCredentialsDTO loginCredentialsDto)
    {
        var user = _userRepository.GetUserByUsernameAndPassword(loginCredentialsDto.Username,
            loginCredentialsDto.Password);
        if (user == null)
        {
            throw new Exception("Username and/or password does not match!");
        }

        return user;
    }
}