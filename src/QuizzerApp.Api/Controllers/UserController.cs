using MediatR;
using Microsoft.AspNetCore.Mvc;

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


}
