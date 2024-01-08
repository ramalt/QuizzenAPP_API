using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByQuestionId;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByUserId;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly ISender _sender;

    public AnswerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnswer(CreateAnswerCommand command)
    {
        var res = await _sender.Send(command);

        if (res)
            return StatusCode(201);

        throw new Exception();
    }

    [HttpGet("/q/{questionId}")]
    public async Task<IActionResult> GetAnswersByQuestion(Guid questionId)
    {
        ReadAnsersByQuestionIdQuery query = new(QuestionId: questionId);

        var res = await _sender.Send(query);

        return Ok(res);

    }

    [HttpGet("/u/{userId}")]
    public async Task<IActionResult> GetAnswersByUser(string userId)
    {
        ReadAnswersByUserIdQuery query = new(UserId: userId);

        var res = await _sender.Send(query);

        return Ok(res);

    }
}
