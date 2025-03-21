using System;

namespace Server.Dtos;

public class LoginRequest
{
    string Identifier { get; }

    string Password { get; } 
}
