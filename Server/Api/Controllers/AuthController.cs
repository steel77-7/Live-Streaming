using Microsoft.AspNetCore.Mvc;
using Server.Application_.Services;
using Server.Application_.Interfaces;

using Server.Dtos;
using Server.Infrastructure.Entities;


namespace Server.Controllers;

[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _uservice;

    public UserController(IUserService u)
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
        Console.WriteLine(1);

       bool status= await _uservice.CreateUser(
            new User()
            {
                Email = res.Email,
                Username = res.Username,
                Password = res.Password,
            }
        );
        Console.WriteLine("In the contoler" + status);
        return Ok(res);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest res)
    {
        User r = await _uservice.GetByEmail(res.Identifier);
        
        return Ok(r);
    }
}
