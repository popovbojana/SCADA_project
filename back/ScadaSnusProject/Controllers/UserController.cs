using Microsoft.AspNetCore.Mvc;
using ScadaSnusProject.DTOs;
using ScadaSnusProject.Model;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    private IUserService _userService;

    public UserController(IUserService userService) 
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("registration")]
    public ActionResult Registration(RegisterUserDTO registerUser)
    {
        try
        {
            var user = _userService.RegisterNewUser(registerUser);
            return Ok($"Successfully registered as {user.Username}!");
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
    
    [HttpPost]
    [Route("login")]
    public ActionResult Login(LoginCredentialsDTO loginCredentials)
    {
        try
        {
            var user = _userService.Login(loginCredentials);
            return Ok($"Successfully logged in as {user.Username}!");
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

}