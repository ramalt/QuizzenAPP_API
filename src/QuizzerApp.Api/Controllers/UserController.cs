using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.User.CreateUserImage;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        return Ok("TODO:");
    }

    [HttpPost("img")]
    public async Task<IActionResult> AddUserImage(IFormFile Image, string userId)
    {
        CreateUserImageCommand commnad = new(Image, userId);

        var res = await _sender.Send(commnad);

        return StatusCode(201);
    }
}
