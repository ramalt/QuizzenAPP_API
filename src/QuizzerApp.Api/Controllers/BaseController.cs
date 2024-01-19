using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace QuizzerApp.Api.Controllers;


public class BaseController : ControllerBase
{
    public string? UserId => HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
}
