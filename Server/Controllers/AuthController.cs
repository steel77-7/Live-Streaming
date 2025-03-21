using System;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;

namespace Server.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("check")]
    public IActionResult Check()
    {
        return Ok(new { Message = "Auth endpoint working!" });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest res)
    {
        return Ok(res);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest res)
    {
        return Ok(res);
    }
}
