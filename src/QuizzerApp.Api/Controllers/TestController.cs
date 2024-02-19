using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TestController : BaseController
{

    [HttpGet]
    public async Task<IActionResult> Health()
    {
        return Ok("I'm Ok.");
    }
}
