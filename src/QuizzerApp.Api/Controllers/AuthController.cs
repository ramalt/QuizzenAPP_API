using System.Drawing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Dtos.Auth;
using QuizzerApp.Application.Features.Commands.User.CreateUser;
using QuizzerApp.Application.Features.Commands.User.GetNewToken;
using QuizzerApp.Application.Features.Commands.User.Login;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginCommand command)
    {
        var res = await _sender.Send(command);

        Response.Cookies.Append("refreshToken", res.RefreshToken);

        LoginDto loginDto = new(res.Token);

        return Ok(loginDto);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var res = await _sender.Send(command);


        return Ok(res);
    }

    [HttpGet("refresh")]
    public async Task<IActionResult> GetNewToken([FromHeader] string authorization)
    {
        _ = Request.Cookies.TryGetValue("refreshToken", out string? refreshToken);

        if (string.IsNullOrEmpty(refreshToken))
            throw new Exception("refresh token not found");

        string[] token = authorization.Split(" ");

        var res = await _sender.Send(new GetNewTokenCommand(token[1], refreshToken));

        Response.Cookies.Append("refreshToken", res.RefreshToken, new CookieOptions { HttpOnly = true });

        LoginDto loginDto = new(res.Token);
        return Ok(loginDto);
    }

}
