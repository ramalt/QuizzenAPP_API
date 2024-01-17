using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.User.CreateUserImage;
using QuizzerApp.Application.Features.Queries.User;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
    {
        GetUserDataQuery query = new(id);

        var res = await _sender.Send(query);
        return Ok(res);
    }

    [HttpPost("img")]
    public async Task<IActionResult> AddUserImage(IFormFile Image, string userId)
    {
        CreateUserImageCommand commnad = new(Image, userId);

        var res = await _sender.Send(commnad);

        return StatusCode(201);
    }
}
