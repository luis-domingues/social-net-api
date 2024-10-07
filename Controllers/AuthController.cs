using Microsoft.AspNetCore.Mvc;
using SocialNetApi.Entities;
using SocialNetApi.Services;

namespace SocialNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginRequest)
    {
        var user = new User
        {
            Id = 1,
            Username = loginRequest.Username,
            Email = "user@test.com",
            Password = "PassHashHere"
        };
        
        if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            return Unauthorized();
        
        var token = _authService.GenerateToken(user);

        return Ok(new { Token = token });
    }
}