using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        return Ok(res);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var res = await _sender.Send(command);

        return Ok(res);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> GetNewToken(GetNewTokenCommand command)
    {
        var res = await _sender.Send(command);

        return Ok(res);
    }

}
