using Microsoft.AspNetCore.Mvc;
using Server.Application_.Services;
using Server.Dtos;
using Server.Infrastructure.Entities;

namespace Server.Controllers;

[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserServices _uservice;

    public UserController(UserServices u)
    {
        _uservice = u;
    }

    [HttpGet("check")]
    public IActionResult Check()
    {
        return Ok(new { Message = "Auth endpoint working!" });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest res)
    {
       bool status= await _uservice.CreateUser(
            new User()
            {
                Email = res.Email,
                Username = res.Username,
                Password = res.Password,
            }
        );
        return Ok(res);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest res)
    {
        return Ok(res);
    }
}
